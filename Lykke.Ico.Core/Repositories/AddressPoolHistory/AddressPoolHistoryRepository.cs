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
        private static string GetPartitionKey() => "";
        private static string GetRowKey(string email) => email;

        public AddressPoolHistoryRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _table = AzureTableStorage<AddressPoolHistoryEntity>.Create(connectionStringManager, "AddressPoolHistory", log);
        }

        public async Task<IAddressPoolHistoryItem> GetAsync(string email)
        {
            return await _table.GetDataAsync(GetPartitionKey(), GetRowKey(email));
        }

        public async Task SaveAsync(IAddressPoolItem addressPoolItem, string email)
        {
            await _table.InsertOrReplaceAsync(new AddressPoolHistoryEntity
            {
                PartitionKey = GetPartitionKey(),
                RowKey = GetRowKey(email),
                BtcPublicKey = addressPoolItem.BtcPublicKey,
                EthPublicKey = addressPoolItem.EthPublicKey
            });
        }

        public async Task RemoveAsync(string email)
        {
            await _table.DeleteIfExistAsync(GetPartitionKey(), GetRowKey(email));
        }
    }
}
