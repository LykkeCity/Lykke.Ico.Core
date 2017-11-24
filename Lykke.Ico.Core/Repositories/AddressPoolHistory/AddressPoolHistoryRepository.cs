using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.SettingsReader;
using System.Linq;
using Common;
using Lykke.Ico.Core.Repositories.AddressPool;

namespace Lykke.Ico.Core.Repositories.AddressPoolHistory
{
    public class AddressPoolHistoryRepository : IAddressPoolHistoryRepository
    {
        private readonly INoSQLTableStorage<AddressPoolHistoryEntity> _table;
        private static string GetPartitionKey(string email) => email;
        private static string GetRowKey() => DateTime.UtcNow.ToString("o");

        public AddressPoolHistoryRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _table = AzureTableStorage<AddressPoolHistoryEntity>.Create(connectionStringManager, "AddressPoolHistory", log);
        }

        public async Task<IEnumerable<IAddressPoolHistoryItem>> GetAsync(string email)
        {
            return await _table.GetDataAsync(GetPartitionKey(email));
        }

        public async Task SaveAsync(IAddressPoolItem addressPoolItem, string email)
        {
            await _table.InsertOrReplaceAsync(new AddressPoolHistoryEntity
            {
                PartitionKey = GetPartitionKey(email),
                RowKey = GetRowKey(),
                BtcPublicKey = addressPoolItem.BtcPublicKey,
                EthPublicKey = addressPoolItem.EthPublicKey
            });
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
