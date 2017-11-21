using Lykke.AzureStorage.Tables;

namespace Lykke.Ico.Core.Repositories.Campaign
{
    internal class CampaignEntity : AzureTableEntity, ICampaign
    {
        public decimal TotalRaised { get; set; }
    }
}
