using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.Ico.Core.Contracts.Repositories;
using Lykke.SettingsReader;
using System.Threading.Tasks;
using System.Linq;

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

        public async Task<IAddressPoolItem> GetNextFreeAsync()
        {
            return (await _table.GetDataAsync("")).FirstOrDefault();
        }

        public async Task<IAddressPoolItem> AddAsync(string ethPulicKey, string btcPublicKey)
        {
            var entity = AddressPoolEntity.Create(ethPulicKey, btcPublicKey);

            entity.PartitionKey = GetPartitionKey("");
            entity.RowKey = GetRowKey(ethPulicKey, btcPublicKey);

            await _table.InsertAsync(entity);

            return entity;
        }
    }
}
