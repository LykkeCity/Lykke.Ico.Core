using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.SettingsReader;

namespace Lykke.Ico.Core.Repositories.CryptoInvestment
{
    public class CryptoInvestmentRepository : ICryptoInvestmentRepository
    {
        private readonly INoSQLTableStorage<CryptoInvestmentEntity> _tableStorage;
        private static string GetPartitionKey(string investorEmail) => investorEmail;
        private static string GetRowKey(string txId) => txId;

        public CryptoInvestmentRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _tableStorage = AzureTableStorage<CryptoInvestmentEntity>.Create(connectionStringManager, "CryptoInvestments", log);
        }

        public async Task<IEnumerable<ICryptoInvestment>> GetInvestmentsAsync(string investorEmail)
        {
            return await _tableStorage.GetDataAsync(GetPartitionKey(investorEmail));
        }

        public async Task SaveAsync(ICryptoInvestment entity)
        {
            await _tableStorage.InsertOrReplaceAsync(new CryptoInvestmentEntity
            {
                PartitionKey = GetPartitionKey(entity.InvestorEmail),
                RowKey = GetRowKey(entity.TransactionId),
                BlockId = entity.BlockId,
                BlockTimestamp = entity.BlockTimestamp,
                DestinationAddress = entity.DestinationAddress,
                CurrencyType = entity.CurrencyType,
                Amount = entity.Amount,
                ExchangeRate = entity.ExchangeRate,
                AmountUsd = entity.AmountUsd,
                Price = entity.Price,
                AmountVld = entity.AmountVld,
                Context = entity.Context
            });
        }

        public async Task SaveEmailTimestampAsync(string investorEmail, string txId, DateTime? timestamp = null)
        {
            var partitionKey = GetPartitionKey(investorEmail);
            var rowKey = GetRowKey(txId);

            await _tableStorage.MergeAsync(partitionKey, rowKey, e =>
            {
                e.EmailTimestamp = timestamp ?? DateTime.Now.ToUniversalTime();
                return e;
            });
        }
    }
}
