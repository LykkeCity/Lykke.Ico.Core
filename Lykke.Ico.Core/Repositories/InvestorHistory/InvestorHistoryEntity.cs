using Lykke.AzureStorage.Tables;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Ico.Core.Repositories.InvestorHistory
{
    public class InvestorHistoryEntity : AzureTableEntity, IInvestorHistoryItem
    {
        [IgnoreProperty]
        public string Email { get => PartitionKey; }

        [IgnoreProperty]
        public string When { get => RowKey; }

        public InvestorHistoryAction Action { get; set; }

        public string Json { get; set; }
    }
}
