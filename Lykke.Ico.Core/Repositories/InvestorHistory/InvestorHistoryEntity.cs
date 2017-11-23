using Lykke.AzureStorage.Tables;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Lykke.Ico.Core.Repositories.InvestorHistory
{
    public class InvestorHistoryEntity : AzureTableEntity, IInvestorHistoryItem
    {
        [IgnoreProperty]
        public string Email { get => PartitionKey; }

        [IgnoreProperty]
        public DateTime WhenUtc { get => Timestamp.UtcDateTime; }

        public InvestorHistoryAction Action { get; set; }

        public string Json { get; set; }
    }
}
