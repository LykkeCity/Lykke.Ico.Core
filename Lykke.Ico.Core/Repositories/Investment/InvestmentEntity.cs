using Lykke.AzureStorage.Tables;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Ico.Core.Repositories.Investment
{
    internal class InvestmentEntity : AzureTableEntity, IInvestment
    {
        [IgnoreProperty] public string Email { get => PartitionKey; }
        [IgnoreProperty] public string Transaction { get => RowKey; }
        public CurrencyType CurrencyType { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountUsd { get; set; }
    }
}
