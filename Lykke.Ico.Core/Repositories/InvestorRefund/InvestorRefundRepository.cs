using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.SettingsReader;
using System;

namespace Lykke.Ico.Core.Repositories.InvestorRefund
{
    public class InvestorRefundRepository : IInvestorRefundRepository
    {
        private readonly INoSQLTableStorage<InvestorRefundEntity> _tableStorage;
        private static string GetPartitionKey(string investorEmail) => investorEmail;
        private static string GetRowKey() => DateTime.UtcNow.ToString("o");

        public InvestorRefundRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _tableStorage = AzureTableStorage<InvestorRefundEntity>.Create(connectionStringManager, "InvestorRefunds", log);
        }

        public async Task<IEnumerable<IInvestorRefund>> GetAllAsync()
        {
            var entities = await _tableStorage.GetDataAsync();

            return entities.OrderBy(f => f.CreatedUtc);
        }

        public async Task<IEnumerable<IInvestorRefund>> GetByEmailAsync(string email)
        {
            var entities = await _tableStorage.GetDataAsync(GetPartitionKey(email));

            return entities.OrderBy(f => f.CreatedUtc);
        }

        public async Task SaveAsync(string email, InvestorRefundReason reason, string messageJson)
        {
            await _tableStorage.InsertOrReplaceAsync(new InvestorRefundEntity
            {
                PartitionKey = GetPartitionKey(email),
                RowKey = GetRowKey(),
                Reason = reason,
                MessageJson = messageJson
            });
        }

        public async Task RemoveAsync(string email)
        {
            var items = await _tableStorage.GetDataAsync(GetPartitionKey(email));

            await _tableStorage.DeleteAsync(items);
        }
    }
}
