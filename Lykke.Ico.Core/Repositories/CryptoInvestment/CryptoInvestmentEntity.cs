using System;
using Lykke.AzureStorage.Tables;
using Lykke.AzureStorage.Tables.Entity.Annotation;
using Lykke.AzureStorage.Tables.Entity.ValueTypesMerging;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Ico.Core.Repositories.CryptoInvestment
{
    [ValueTypeMergingStrategy(ValueTypeMergingStrategy.UpdateAlways)]
    internal class CryptoInvestmentEntity : AzureTableEntity, ICryptoInvestment
    {
        [IgnoreProperty]
        public string InvestorEmail
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
        public decimal Amount { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal AmountUsd { get; set; }
        public decimal Price { get; set; }
        public decimal AmountVld { get; set; }
        public string Context { get; set; }
        public DateTimeOffset? EmailSent { get; set; }
    }
}
