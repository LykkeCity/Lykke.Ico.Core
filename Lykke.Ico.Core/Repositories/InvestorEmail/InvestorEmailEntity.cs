using Lykke.AzureStorage.Tables;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Lykke.Ico.Core.Repositories.InvestorEmail
{
    internal class InvestorEmailEntity : AzureTableEntity, IInvestorEmail
    {
        [IgnoreProperty]
        public string Email { get => PartitionKey; }

        [IgnoreProperty]
        public DateTime WhenUtc { get => Timestamp.UtcDateTime; }

        public string Type { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
