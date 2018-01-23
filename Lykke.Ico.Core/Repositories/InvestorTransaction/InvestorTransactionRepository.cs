using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.SettingsReader;

namespace Lykke.Ico.Core.Repositories.InvestorTransaction
{
    public class InvestorTransactionRepository : IInvestorTransactionRepository
    {
        private readonly INoSQLTableStorage<InvestorTransactionEntity> _table;
        private static string GetPartitionKey(string investorEmail) => investorEmail;
        private static string GetRowKey(string txId) => txId;

        public InvestorTransactionRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _table = AzureTableStorage<InvestorTransactionEntity>.Create(connectionStringManager, "InvestorTransactions", log);
        }

        public async Task<IInvestorTransaction> GetAsync(string email, string uniqueId)
        {
            return await _table.GetDataAsync(GetPartitionKey(email), GetRowKey(uniqueId));
        }

        public async Task<IEnumerable<IInvestorTransaction>> GetByEmailAsync(string email)
        {
            var entities = await _table.GetDataAsync(GetPartitionKey(email));

            return entities.OrderBy(f => f.CreatedUtc);
        }

        public async Task SaveAsync(IInvestorTransaction tx)
        {
            await _table.InsertOrReplaceAsync(new InvestorTransactionEntity
            {
                PartitionKey = GetPartitionKey(tx.Email),
                RowKey = GetRowKey(tx.UniqueId),
                CreatedUtc = tx.CreatedUtc,
                Currency = tx.Currency,
                BlockId = tx.BlockId,
                PayInAddress = tx.PayInAddress,
                TransactionId = tx.TransactionId,
                Amount = tx.Amount,
                AmountUsd = tx.AmountUsd,
                AmountToken = tx.AmountToken,
                TokenPrice = tx.TokenPrice,
                TokenPriceContext = tx.TokenPriceContext,
                ExchangeRate = tx.ExchangeRate,
                ExchangeRateContext = tx.ExchangeRateContext,
                Fee = tx.Fee
            });
        }

        public async Task RemoveAsync(string email)
        {
            var items = await _table.GetDataAsync(GetPartitionKey(email));
            
            await _table.DeleteAsync(items);
        }
    }
}
