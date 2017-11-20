﻿using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.SettingsReader;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.Investor
{
    public class InvestorRepository : IInvestorRepository
    {
        private readonly INoSQLTableStorage<InvestorEntity> _table;
        private static string GetPartitionKey() => "Investor";
        private static string GetRowKey(string email) => email;

        public InvestorRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _table = AzureTableStorage<InvestorEntity>.Create(connectionStringManager, "Investors", log);
        }

        public async Task<IEnumerable<IInvestor>> GetAllAsync()
        {
            return await _table.GetDataAsync(GetPartitionKey());
        }

        public async Task<IInvestor> GetAsync(string email)
        {
            return await _table.GetDataAsync(GetPartitionKey(), GetRowKey(email));
        }

        public async Task<IInvestor> AddAsync(string email)
        {
            var entity = InvestorEntity.Create(email);

            entity.PartitionKey = GetPartitionKey();
            entity.RowKey = GetRowKey(email);

            await _table.InsertAsync(entity);

            return entity;
        }

        public async Task UpdateAsync(IInvestor investor)
        {
            await _table.MergeAsync(GetPartitionKey(), GetRowKey(investor.Email), x =>
            {
                x.TokenAddress = investor.TokenAddress;
                x.RefundEthAddress = investor.RefundEthAddress;
                x.RefundBtcAddress = investor.RefundBtcAddress;
                x.PayInEthPublicKey = investor.PayInEthPublicKey;
                x.PayInEthAddress = investor.PayInEthAddress;
                x.PayInBtcPublicKey = investor.PayInBtcPublicKey;
                x.PayInBtcAddress = investor.PayInBtcAddress;
                x.ConfirmationToken = investor.ConfirmationToken;
                x.ConfirmationDateTime = investor.ConfirmationDateTime;
                x.Updated = DateTime.Now;

                return x;
            });
        }

        public async Task RemoveAsync(string email)
        {
            await _table.DeleteIfExistAsync(GetPartitionKey(), GetRowKey(email));
        }
    }
}
