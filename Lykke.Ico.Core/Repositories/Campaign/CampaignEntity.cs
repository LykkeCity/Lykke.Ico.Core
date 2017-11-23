using Lykke.AzureStorage.Tables;
using Lykke.AzureStorage.Tables.Entity.Annotation;
using Lykke.AzureStorage.Tables.Entity.ValueTypesMerging;

namespace Lykke.Ico.Core.Repositories.Campaign
{
    [ValueTypeMergingStrategy(ValueTypeMergingStrategy.UpdateAlways)]
    internal class CampaignEntity : AzureTableEntity, ICampaign
    {
        public decimal TotalRaised { get; set; }
    }
}
