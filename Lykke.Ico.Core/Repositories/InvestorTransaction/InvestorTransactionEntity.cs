using System;
using Lykke.AzureStorage.Tables;
using Lykke.AzureStorage.Tables.Entity.Annotation;
using Lykke.AzureStorage.Tables.Entity.ValueTypesMerging;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Ico.Core.Repositories.InvestorTransaction
{
    [ValueTypeMergingStrategy(ValueTypeMergingStrategy.UpdateAlways)]
    internal class InvestorTransactionEntity : AzureTableEntity, IInvestorTransaction
    {
        [IgnoreProperty]
        public string Email
        {
            get => PartitionKey;
        }

        [IgnoreProperty]
        public string UniqueId
        {
            get => RowKey;
        }

        public DateTime CreatedUtc { get; set; }
        public CurrencyType Currency { get; set; }
        public string TransactionId { get; set; }
        public string BlockId { get; set; }
        public string PayInAddress { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountUsd { get; set; }
        public decimal AmountToken { get; set; }
        public decimal Fee { get; set; }
        public decimal TokenPrice { get; set; }
        public string TokenPriceContext { get; set; }
        public decimal ExchangeRate { get; set; }
        public string ExchangeRateContext { get; set; }
    }
}
