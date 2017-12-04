using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.Ico.Core.Repositories.InvestorHistory;
using Lykke.SettingsReader;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.Investor
{
    public class InvestorRepository : IInvestorRepository
    {
        private static readonly Object _lock = new Object();
        private readonly INoSQLTableStorage<InvestorEntity> _table;
        private static string GetPartitionKey() => "Investor";
        private static string GetRowKey(string email) => email;

        private readonly IInvestorHistoryRepository _investorHistoryRepository;

        public InvestorRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _table = AzureTableStorage<InvestorEntity>.Create(connectionStringManager, "Investors", log);
            _investorHistoryRepository = new InvestorHistoryRepository(connectionStringManager, log);
        }

        public async Task<IEnumerable<IInvestor>> GetAllAsync()
        {
            return await _table.GetDataAsync(GetPartitionKey());
        }

        public async Task<IInvestor> GetAsync(string email)
        {
            return await _table.GetDataAsync(GetPartitionKey(), GetRowKey(email));
        }

        public async Task<IInvestor> AddAsync(string email, Guid confirmationToken)
        {
            var entity = new InvestorEntity
            {
                PartitionKey = GetPartitionKey(),
                RowKey = GetRowKey(email),
                ConfirmationToken = confirmationToken,
                ConfirmationTokenCreatedUtc = DateTime.UtcNow,
                UpdatedUtc = DateTime.UtcNow
            };

            await _table.InsertAsync(entity);
            await _investorHistoryRepository.SaveAsync(entity, InvestorHistoryAction.Create);

            return entity;
        }

        public async Task ConfirmAsync(string email)
        {
            var entity = await _table.MergeAsync(GetPartitionKey(), GetRowKey(email), x =>
            {
                x.ConfirmedUtc = DateTime.UtcNow;
                x.UpdatedUtc = DateTime.UtcNow;

                return x;
            });

            await _investorHistoryRepository.SaveAsync(entity, InvestorHistoryAction.Update);
        }

        public async Task SaveAddressesAsync(string email, string tokenAddress, string refundEthAddress, string refundBtcAddress,
           string payInEthPublicKey, string payInEthAddress, string payInBtcPublicKey, string payInBtcAddress)
        {
            var entity = await _table.MergeAsync(GetPartitionKey(), GetRowKey(email), x =>
            {
                x.TokenAddress = tokenAddress;
                x.RefundEthAddress = refundEthAddress;
                x.RefundBtcAddress = refundBtcAddress;
                x.PayInEthPublicKey = payInEthPublicKey;
                x.PayInEthAddress = payInEthAddress;
                x.PayInBtcPublicKey = payInBtcPublicKey;
                x.PayInBtcAddress = payInBtcAddress;
                x.UpdatedUtc = DateTime.UtcNow;

                return x;
            });

            await _investorHistoryRepository.SaveAsync(entity, InvestorHistoryAction.Update);
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

            await _investorHistoryRepository.SaveAsync(entity, InvestorHistoryAction.Update);
        }

        public async Task SaveKycResultAsync(string email, bool kycPassed)
        {
            var entity = await _table.MergeAsync(GetPartitionKey(), GetRowKey(email), x =>
            {
                x.KycPassed = kycPassed;
                x.KycPassedUtc = DateTime.UtcNow;
                x.UpdatedUtc = DateTime.UtcNow;

                return x;
            });

            await _investorHistoryRepository.SaveAsync(entity, InvestorHistoryAction.Update);
        }

        public async Task IncrementBtc(string email, decimal amountBtc, decimal amountUsd, decimal amountVld)
        {
            var entity = await _table.MergeAsync(GetPartitionKey(), GetRowKey(email), x =>
            {
                x.AmountBtc += amountBtc;
                x.AmountUsd += amountUsd;
                x.AmountVld = amountVld;
                x.UpdatedUtc = DateTime.UtcNow;

                return x;
            });

            await _investorHistoryRepository.SaveAsync(entity, InvestorHistoryAction.Update);
        }

        public async Task IncrementEth(string email, decimal amountEth, decimal amountUsd, decimal amountVld)
        {
            var entity = await _table.MergeAsync(GetPartitionKey(), GetRowKey(email), x =>
            {
                x.AmountEth += amountEth;
                x.AmountUsd += amountUsd;
                x.AmountVld = amountVld;
                x.UpdatedUtc = DateTime.UtcNow;

                return x;
            });

            await _investorHistoryRepository.SaveAsync(entity, InvestorHistoryAction.Update);
        }

        public async Task IncrementFiat(string email, decimal amountFiat, decimal amountUsd, decimal amountVld)
        {
            var entity = await _table.MergeAsync(GetPartitionKey(), GetRowKey(email), x =>
            {
                x.AmountFiat += amountFiat;
                x.AmountUsd += amountUsd;
                x.AmountVld = amountVld;
                x.UpdatedUtc = DateTime.UtcNow;

                return x;
            });

            await _investorHistoryRepository.SaveAsync(entity, InvestorHistoryAction.Update);
        }

        public async Task RemoveAsync(string email)
        {
            await _table.DeleteIfExistAsync(GetPartitionKey(), GetRowKey(email));
        }
    }
}
