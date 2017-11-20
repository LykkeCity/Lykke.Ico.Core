using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Log;
using AzureStorage;
using AzureStorage.Tables;
using Lykke.SettingsReader;
using Lykke.Ico.Core.Repositories.InvestorToken;
using Lykke.Ico.Core.Contracts.Repositories;

namespace Lykke.Ico.Core.Repositories.InvestorConfirmation
{
    public class InvestorConfirmationRepository : IInvestorConfirmationRepository
    {
        private readonly INoSQLTableStorage<InvestorConfirmationEntity> _table;
        private static string GetPartitionKey() => "InvestorConfirmation";
        private static string GetRowKey(Guid token) => token.ToString();

        public InvestorConfirmationRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _table = AzureTableStorage<InvestorConfirmationEntity>.Create(connectionStringManager, "InvestorsConfirmation", log);
        }

        public async Task<IInvestorConfirmation> GetAsync(Guid confirmationToken)
        {
            return await _table.GetDataAsync(GetPartitionKey(), GetRowKey(confirmationToken));
        }

        public async Task<IInvestorConfirmation> GetAsync(string email)
        {
            return (await _table.GetDataAsync(GetPartitionKey())).FirstOrDefault();
        }

        public async Task<IInvestorConfirmation> AddAsync(string email, string ipAddress)
        {
            var entity = InvestorConfirmationEntity.Create(email, ipAddress);

            entity.PartitionKey = GetPartitionKey();
            entity.RowKey = GetRowKey(entity.ConfirmationToken);

            await _table.InsertAsync(entity);

            return entity;
        }

        public async Task ConfirmAsync(Guid confirmationToken)
        {
            await _table.MergeAsync(GetPartitionKey(), GetRowKey(confirmationToken), x =>
            {
                x.ConfirmationDateTime = DateTime.Now;

                return x;
            });
        }
    }
}
