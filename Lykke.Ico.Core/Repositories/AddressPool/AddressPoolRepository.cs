using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.SettingsReader;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;
using Lykke.Ico.Core.Repositories.AddressPoolHistory;

namespace Lykke.Ico.Core.Repositories.AddressPool
{
    public class AddressPoolRepository : IAddressPoolRepository
    {
        private static readonly Object _lock = new Object();
        private readonly INoSQLTableStorage<AddressPoolEntity> _table;
        private readonly IAddressPoolHistoryRepository _addressPoolHistoryRepository;
        private static string GetPartitionKey() => "";
        private static string GetRowKey() => (DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks).ToString("d19");

        public AddressPoolRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _table = AzureTableStorage<AddressPoolEntity>.Create(connectionStringManager, "AddressPool", log);
            _addressPoolHistoryRepository = new AddressPoolHistoryRepository(connectionStringManager, log);
        }

        public IAddressPoolItem GetNextFree(string email)
        {
            lock (_lock)
            {
                var query = new Microsoft.WindowsAzure.Storage.Table.TableQuery<AddressPoolEntity>().Take(1);
                //var page = new AzureStorage.Tables.Paging.PagingInfo();
                //var result = _table.ExecuteQueryWithPaginationAsync(query, page).Result;

                var result = new List<AddressPoolEntity>();
                _table.ExecuteAsync(query, entities =>
                {
                    result.AddRange(entities);
                });

                var entity = result.FirstOrDefault();
                if (entity == null)
                {
                    throw new Exception("There are no free addresses in address pool");
                }

                _addressPoolHistoryRepository.SaveAsync(entity, email);
                _table.DeleteAsync(entity).Wait();

                return entity;
            }
        }

        public async Task AddAsync(string ethPulicKey, string btcPublicKey)
        {
            await _table.InsertAsync(new AddressPoolEntity
            {
                EthPublicKey = ethPulicKey,
                BtcPublicKey = btcPublicKey,
                PartitionKey = GetPartitionKey(),
                RowKey = GetRowKey()
            });
        }

        public async Task AddBatchAsync(List<IAddressPoolItem> keys)
        {
            var entities = keys.Select(f => new AddressPoolEntity
            {
                BtcPublicKey = f.BtcPublicKey,
                EthPublicKey = f.EthPublicKey,
                PartitionKey = GetPartitionKey(),
                RowKey = GetRowKey()
            });

            await _table.InsertOrMergeBatchAsync(entities);
        }
    }
}
