using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.SettingsReader;

namespace Lykke.Ico.Core.Repositories.CryptoInvestment
{
    public class InvestorTransactionRepository : IInvestorTransactionRepository
    {
        private readonly INoSQLTableStorage<InvestorTransactionEntity> _tableStorage;
        private static string GetPartitionKey(string investorEmail) => investorEmail;
        private static string GetRowKey(string txId) => txId;

        public InvestorTransactionRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _tableStorage = AzureTableStorage<InvestorTransactionEntity>.Create(connectionStringManager, "InvestorTransactions", log);
        }

        public async Task<IInvestorTransaction> GetAsync(string email, string transactionId)
        {
            return await _tableStorage.GetDataAsync(GetPartitionKey(email), GetRowKey(transactionId));
        }

        public async Task<IEnumerable<IInvestorTransaction>> GetByEmailAsync(string email)
        {
            var entities = await _tableStorage.GetDataAsync(GetPartitionKey(email));

            return entities.OrderBy(f => f.CreatedUtc);
        }

        public async Task SaveAsync(IInvestorTransaction entity)
        {
            await _tableStorage.InsertOrReplaceAsync(new InvestorTransactionEntity
            {
                PartitionKey = GetPartitionKey(entity.Email),
                RowKey = GetRowKey(entity.TransactionId),
                CreatedUtc = entity.CreatedUtc,
                Currency = entity.Currency,
                BlockId = entity.BlockId,
                PayInAddress = entity.PayInAddress,
                Transaction = entity.Transaction,
                Amount = entity.Amount,
                AmountUsd = entity.AmountUsd,
                AmountToken = entity.AmountToken,
                TokenPrice = entity.TokenPrice,
                ExchangeRate = entity.ExchangeRate,
                ExchangeRateContext = entity.ExchangeRateContext
            });
        }

        public async Task RemoveAsync(string email)
        {
            var items = await _tableStorage.GetDataAsync(GetPartitionKey(email));
            
            await _tableStorage.DeleteAsync(items);
        }
    }
}
