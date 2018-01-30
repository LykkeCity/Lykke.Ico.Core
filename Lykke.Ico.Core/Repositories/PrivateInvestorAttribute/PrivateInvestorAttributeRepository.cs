using System;
using System.Threading.Tasks;
using AzureStorage;
using AzureStorage.Tables;
using Lykke.SettingsReader;
using Common.Log;

namespace Lykke.Ico.Core.Repositories.PrivateInvestorAttribute
{
    public class PrivateInvestorAttributeRepository : IPrivateInvestorAttributeRepository
    {
        private readonly INoSQLTableStorage<PrivateInvestorAttributeEntity> _table;
        private static string GetPartitionKey(PrivateInvestorAttributeType type) => Enum.GetName(typeof(PrivateInvestorAttributeType), type);
        private static string GetRowKey(string value) => value;

        public PrivateInvestorAttributeRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _table = AzureTableStorage<PrivateInvestorAttributeEntity>.Create(connectionStringManager, "PrivateInvestorAttributes", log);
        }

        public async Task<string> GetInvestorEmailAsync(PrivateInvestorAttributeType type, string value)
        {
            var attribute = await _table.GetDataAsync(GetPartitionKey(type), GetRowKey(value));

            return attribute?.Email;
        }

        public async Task SaveAsync(PrivateInvestorAttributeType type, string email, string value)
        {
            var entity = PrivateInvestorAttributeEntity.Create(email);

            entity.PartitionKey = GetPartitionKey(type);
            entity.RowKey = GetRowKey(value);

            await _table.InsertOrMergeAsync(entity);
        }

        public async Task RemoveAsync(PrivateInvestorAttributeType type, string value)
        {
            await _table.DeleteIfExistAsync(GetPartitionKey(type), GetRowKey(value));
        }
    }
}
