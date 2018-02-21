using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.SettingsReader;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.PrivateInvestor
{
    public class PrivateInvestorRepository : IPrivateInvestorRepository
    {
        private readonly INoSQLTableStorage<PrivateInvestorEntity> _table;
        private static string GetPartitionKey() => "";
        private static string GetRowKey(string email) => email;

        public PrivateInvestorRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _table = AzureTableStorage<PrivateInvestorEntity>.Create(connectionStringManager, "PrivateInvestors", log);
        }

        public async Task<IEnumerable<IPrivateInvestor>> GetAllAsync()
        {
            return await _table.GetDataAsync(GetPartitionKey());
        }

        public async Task<IPrivateInvestor> GetAsync(string email)
        {
            return await _table.GetDataAsync(GetPartitionKey(), GetRowKey(email));
        }

        public async Task<IPrivateInvestor> AddAsync(string email)
        {
            var entity = new PrivateInvestorEntity
            {
                PartitionKey = GetPartitionKey(),
                RowKey = GetRowKey(email),
                UpdatedUtc = DateTime.UtcNow
            };

            await _table.InsertAsync(entity);

            return entity;
        }

        public async Task SaveKycAsync(string email, string kycRequestId)
        {
            var entity = await _table.MergeAsync(GetPartitionKey(), GetRowKey(email), x =>
            {
                x.KycRequestId = kycRequestId;
                x.KycRequestedUtc = DateTime.UtcNow;
                x.UpdatedUtc = DateTime.UtcNow;

                return x;
            });
        }

        public async Task SaveKycResultAsync(string email, bool? kycPassed, bool manual = false)
        {
            var entity = await _table.ReplaceAsync(GetPartitionKey(), GetRowKey(email), x =>
            {
                x.KycPassed = kycPassed;
                x.KycPassedUtc = kycPassed == null ? (DateTime?)null : DateTime.UtcNow;
                x.KycManuallyUpdatedUtc = manual ? DateTime.UtcNow : (DateTime?)null;
                x.UpdatedUtc = DateTime.UtcNow;

                return x;
            });
        }

        public async Task RemoveAsync(string email)
        {
            await _table.DeleteIfExistAsync(GetPartitionKey(), GetRowKey(email));
        }
    }
}
