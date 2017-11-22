﻿using System;
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

        public async Task SaveAsync(
            string investorEmail,
            string txId,
            string blockId,
            DateTimeOffset blockTimestamp,
            string destinationAddress,
            CurrencyType currencyType,
            decimal amount,
            decimal exchangeRate,
            decimal amountUsd)
        {
            await _tableStorage.InsertOrMergeAsync(new CryptoInvestmentEntity
            {
                PartitionKey = GetPartitionKey(investorEmail),
                RowKey = GetRowKey(txId),
                BlockId = blockId,
                BlockTimestamp = blockTimestamp,
                DestinationAddress = destinationAddress,
                CurrencyType = currencyType,
                Amount = amount,
                ExchangeRate = exchangeRate,
                AmountUsd = amountUsd
            });
        }
    }
}
