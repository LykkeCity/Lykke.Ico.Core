using System.Threading.Tasks;
using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.SettingsReader;
using Lykke.Ico.Core.Repositories.AddressPool;
using System.Collections.Generic;
using System.Linq;

namespace Lykke.Ico.Core.Repositories.AddressPoolHistory
{
    public class AddressPoolHistoryRepository : IAddressPoolHistoryRepository
    {
        private readonly INoSQLTableStorage<AddressPoolHistoryEntity> _table;
        private static string GetPartitionKey() => "";
        private static string GetRowKey(int id) => id.ToString().PadLeft(9, '0');

        public AddressPoolHistoryRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _table = AzureTableStorage<AddressPoolHistoryEntity>.Create(connectionStringManager, "AddressPoolHistory", log);
        }

        public async Task<IEnumerable<IAddressPoolHistoryItem>> Get(int[] ids)
        {
            return await _table.GetDataRowKeysOnlyAsync(ids.Select(f => GetRowKey(f)));
        }

        public async Task SaveAsync(IAddressPoolItem addressPoolItem, string email)
        {
            await _table.InsertOrReplaceAsync(new AddressPoolHistoryEntity
            {
                PartitionKey = GetPartitionKey(),
                RowKey = GetRowKey(addressPoolItem.Id),
                Email = email,
                BtcPublicKey = addressPoolItem.BtcPublicKey,
                EthPublicKey = addressPoolItem.EthPublicKey
            });
        }
    }
}
