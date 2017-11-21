using System.Threading.Tasks;
using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.SettingsReader;

namespace Lykke.Ico.Core.Repositories.Campaign
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly INoSQLTableStorage<CampaignEntity> _tableStorage;

        // currently use exact values for partition and row keys (campaign identifier and stage respectively), 
        // in future should be stored in investorAttributes during registration
        private static string GetPartitionKey() => "IcoCampaign"; 
        private static string GetRowKey() => "PublicSale";

        public CampaignRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _tableStorage = AzureTableStorage<CampaignEntity>.Create(connectionStringManager, "Campaigns", log);
        }

        public async Task<decimal> GetTotalRaisedAsync()
        {
            var partitionKey = GetPartitionKey();
            var rowKey = GetRowKey();
            var entity = await _tableStorage.GetDataAsync(partitionKey, rowKey);

            return entity?.TotalRaised ?? 0M;
        }

        public async Task SaveAsync(decimal totalRaised)
        {
            await _tableStorage.InsertOrReplaceAsync(new CampaignEntity
            {
                PartitionKey = GetPartitionKey(),
                RowKey = GetRowKey(),
                TotalRaised = totalRaised
            });
        }
    }
}
