using System;
using Lykke.AzureStorage.Tables;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Ico.Core.Repositories.Investment
{
    internal class InvestmentEntity : AzureTableEntity, IInvestment
    {
        [IgnoreProperty]
        public string Email
        {
            get => PartitionKey;
        }

        [IgnoreProperty]
        public string TransactionId
        {
            get => RowKey;
        }

        public string BlockId { get; set; }
        public DateTimeOffset BlockTimestamp { get; set; }
        public string DestinationAddress { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountUsd { get; set; }
    }
}
