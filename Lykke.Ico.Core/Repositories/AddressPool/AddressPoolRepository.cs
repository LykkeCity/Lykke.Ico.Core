﻿using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.SettingsReader;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Lykke.Ico.Core.Repositories.AddressPool
{
    public class AddressPoolRepository : IAddressPoolRepository
    {
        private readonly INoSQLTableStorage<AddressPoolEntity> _table;
        private static string GetPartitionKey(string email) => email;
        private static string GetRowKey(string ehtKey, string btcKey) => $"{ehtKey}_{btcKey}";

        public AddressPoolRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _table = AzureTableStorage<AddressPoolEntity>.Create(connectionStringManager, "AddressPool", log);
        }

        public async Task<IAddressPoolItem> GetNextFreeAsync(string email)
        {
            var entity = (await _table.GetDataAsync("")).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception("There are no free addresses in address pool");
            }

            await _table.DeleteAsync(entity);

            entity.PartitionKey = GetPartitionKey(email);

            await _table.InsertAsync(entity);

            return entity;
        }

        public async Task<IAddressPoolItem> AddAsync(string ethPulicKey, string btcPublicKey)
        {
            var entity = AddressPoolEntity.Create(ethPulicKey, btcPublicKey);

            entity.PartitionKey = GetPartitionKey("");
            entity.RowKey = GetRowKey(ethPulicKey, btcPublicKey);

            await _table.InsertAsync(entity);

            return entity;
        }

        public async Task RemoveAsync(string email)
        {
            var items = await _table.GetDataAsync(GetPartitionKey(email));
            if (items.Any())
            {
                await _table.DeleteAsync(items);
            }
        }
    }
}
