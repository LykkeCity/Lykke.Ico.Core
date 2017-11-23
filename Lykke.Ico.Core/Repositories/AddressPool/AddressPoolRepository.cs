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
        private static string GetPartitionKey() => "";
        private static string GetRowKey(string ehtKey, string btcKey) => (DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks).ToString("d19");

        public AddressPoolRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _table = AzureTableStorage<AddressPoolEntity>.Create(connectionStringManager, "AddressPool", log);
        }

        public async Task<IAddressPoolItem> GetNextFreeAsync(string email)
        {
            AddressPoolEntity entity;

            try
            {
                entity = _table.First();
            }
            catch (Exception ex)
            {
                throw new Exception("There are no free addresses in address pool", ex);
            }

            await _table.DeleteAsync(entity);

            return entity;
        }

        public async Task<IAddressPoolItem> AddAsync(string ethPulicKey, string btcPublicKey)
        {
            var entity = AddressPoolEntity.Create(ethPulicKey, btcPublicKey);

            entity.PartitionKey = GetPartitionKey();
            entity.RowKey = GetRowKey(ethPulicKey, btcPublicKey);

            await _table.InsertAsync(entity);

            return entity;
        }
    }
}
