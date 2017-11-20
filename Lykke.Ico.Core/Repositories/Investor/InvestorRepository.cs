using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.Ico.Core.Contracts.Repositories;
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

        public async Task<IInvestor> AddAsync(string email, string ipAddress)
        {
            var entity = InvestorEntity.Create(email, ipAddress);

            entity.PartitionKey = GetPartitionKey();
            entity.RowKey = GetRowKey(email);

            await _table.InsertAsync(entity);

            return entity;
        }

        public async Task UpdateAddressesAsync(string email, string tokenAddress, string refundEthAddress, string refundBtcAddress)
        {
            await _table.MergeAsync(GetPartitionKey(), GetRowKey(email), x =>
            {
                x.TokenAddress = tokenAddress;
                x.RefundEthAddress = refundEthAddress;
                x.RefundBtcAddress = refundBtcAddress;

                return x;
            });
        }

        public async Task UpdatePayInAddressesAsync(string email, string payInEthPublicKey, string payInBtcPublicKey)
        {
            await _table.MergeAsync(GetPartitionKey(), GetRowKey(email), x =>
            {
                x.PayInEthPublicKey = payInEthPublicKey;
                x.PayInBtcPublicKey = payInBtcPublicKey;

                return x;
            });
        }

        public async Task RemoveAsync(string email)
        {
            await _table.DeleteIfExistAsync(GetPartitionKey(), GetRowKey(email));
        }
    }
}
