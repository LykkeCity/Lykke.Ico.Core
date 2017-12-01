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
            var entity = InvestorEntity.Create(email, confirmationToken);

            entity.PartitionKey = GetPartitionKey();
            entity.RowKey = GetRowKey(email);

            await _table.InsertAsync(entity);
            await _investorHistoryRepository.SaveAsync(entity, InvestorHistoryAction.Create);

            return entity;
        }

        public async Task UpdateAsync(IInvestor investor)
        {
            var entity = await _table.MergeAsync(GetPartitionKey(), GetRowKey(investor.Email), x =>
            {
                x.TokenAddress = investor.TokenAddress;
                x.RefundEthAddress = investor.RefundEthAddress;
                x.RefundBtcAddress = investor.RefundBtcAddress;
                x.PayInEthPublicKey = investor.PayInEthPublicKey;
                x.PayInEthAddress = investor.PayInEthAddress;
                x.PayInBtcPublicKey = investor.PayInBtcPublicKey;
                x.PayInBtcAddress = investor.PayInBtcAddress;
                x.ConfirmationToken = investor.ConfirmationToken;
                x.ConfirmationDateTimeUtc = investor.ConfirmationDateTimeUtc;
                x.KycProcessId = investor.KycProcessId;
                x.KycSucceeded = investor.KycSucceeded;
                x.KycResult = investor.KycResult;
                x.AmountBtc = investor.AmountBtc;
                x.AmountEth = investor.AmountEth;
                x.AmountUsd = investor.AmountUsd;
                x.AmountVld = investor.AmountVld;
                x.UpdatedUtc = DateTime.UtcNow;

                return x;
            });

            await _investorHistoryRepository.SaveAsync(entity, InvestorHistoryAction.Update);
        }

        public async Task RemoveAsync(string email)
        {
            await _table.DeleteIfExistAsync(GetPartitionKey(), GetRowKey(email));
            await _investorHistoryRepository.RemoveAsync(email);
        }
    }
}
