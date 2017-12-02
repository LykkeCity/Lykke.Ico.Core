﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
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

        public async Task<ICryptoInvestment> GetAsync(string email, string transactionId)
        {
            return await _tableStorage.GetDataAsync(GetPartitionKey(email), GetRowKey(transactionId));
        }

        public async Task<IEnumerable<ICryptoInvestment>> GetByEmailAsync(string email)
        {
            var entities = await _tableStorage.GetDataAsync(GetPartitionKey(email));

            return entities.OrderBy(f => f.BlockTimestamp);
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

        public async Task RemoveAsync(string email)
        {
            var items = await _tableStorage.GetDataAsync(GetPartitionKey(email));
            
            await _tableStorage.DeleteAsync(items);
        }
    }
}
