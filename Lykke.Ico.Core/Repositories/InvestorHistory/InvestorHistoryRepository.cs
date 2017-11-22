using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.SettingsReader;
using System.Linq;
using Common;
using Lykke.Ico.Core.Repositories.Investor;

namespace Lykke.Ico.Core.Repositories.InvestorHistory
{
    public class InvestorHistoryRepository : IInvestorHistoryRepository
    {
        private readonly INoSQLTableStorage<InvestorHistoryEntity> _table;
        private static string GetPartitionKey(string email) => email;
        private static string GetRowKey() => DateTime.Now.ToString();

        public InvestorHistoryRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _table = AzureTableStorage<InvestorHistoryEntity>.Create(connectionStringManager, "InvestorHistory", log);
        }

        public async Task<IEnumerable<IInvestorHistoryItem>> GetAsync(string email)
        {
            return await _table.GetDataAsync(GetPartitionKey(email));
        }

        public async Task SaveAsync(IInvestor investor, InvestorHistoryAction action)
        {
            await _table.InsertOrReplaceAsync(new InvestorHistoryEntity
            {
                PartitionKey = GetPartitionKey(investor.Email),
                RowKey = GetRowKey(),
                Action = action,
                Json = investor.ToJson()
            });
        }
    }
}
