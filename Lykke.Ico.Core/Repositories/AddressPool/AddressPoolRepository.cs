using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.SettingsReader;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;
using Lykke.Ico.Core.Repositories.AddressPoolHistory;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Ico.Core.Repositories.AddressPool
{
    public class AddressPoolRepository : IAddressPoolRepository
    {
        private static readonly Object _lock = new Object();
        private readonly INoSQLTableStorage<AddressPoolEntity> _table;
        private readonly IAddressPoolHistoryRepository _addressPoolHistoryRepository;
        private static string GetRowKey(int id) => id.ToString().PadLeft(9, '0');

        public AddressPoolRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _table = AzureTableStorage<AddressPoolEntity>.Create(connectionStringManager, "AddressPool", log);
            _addressPoolHistoryRepository = new AddressPoolHistoryRepository(connectionStringManager, log);
        }

        public async Task<IAddressPoolItem> GetNextFree(string email)
        {
            await Task.Yield();

            lock (_lock)
            {
                var query = new TableQuery<AddressPoolEntity>().Take(1);
                var page = new AzureStorage.Tables.Paging.PagingInfo { ElementCount = 1 };
                var result = _table.ExecuteQueryWithPaginationAsync(query, page).Result;

                var entity = result.FirstOrDefault();
                if (entity == null)
                {
                    throw new Exception("There are no free addresses in address pool");
                }

                _addressPoolHistoryRepository.SaveAsync(entity, email).Wait();
                _table.DeleteAsync(entity).Wait();

                return entity;
            }            
        }

        public async Task AddBatchAsync(List<IAddressPoolItem> keys)
        {
            var entities = keys.Select(f => new AddressPoolEntity
            {
                BtcPublicKey = f.BtcPublicKey,
                EthPublicKey = f.EthPublicKey,
                PartitionKey = "",
                RowKey = GetRowKey(f.Id)
            });

            await _table.InsertOrMergeBatchAsync(entities);
        }
    }
}
