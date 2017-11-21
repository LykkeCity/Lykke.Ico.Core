using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.SettingsReader;

namespace Lykke.Ico.Core.Repositories.Investment
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly INoSQLTableStorage<InvestmentEntity> _tableStorage;
        private static string GetPartitionKey(string investorEmail) => investorEmail;
        private static string GetRowKey(string txHash, uint outIdx) => txHash + "_" + outIdx.ToString();

        public InvestmentRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _tableStorage = AzureTableStorage<InvestmentEntity>.Create(connectionStringManager, "Investments", log);
        }

        public async Task<IEnumerable<IInvestment>> GetInvestmentsAsync(string investorEmail)
        {
            return await _tableStorage.GetDataAsync(GetPartitionKey(investorEmail));
        }

        public async Task SaveAsync(string investorEmail, string txHash, uint outputIndex, CurrencyType currencyType, decimal amount, decimal amountUsd)
        {
            await _tableStorage.InsertOrReplaceAsync(new InvestmentEntity
            {
                PartitionKey = GetPartitionKey(investorEmail),
                RowKey = GetRowKey(txHash, outputIndex),
                CurrencyType = currencyType,
                Amount = amount,
                AmountUsd = amountUsd
            });
        }
    }
}
