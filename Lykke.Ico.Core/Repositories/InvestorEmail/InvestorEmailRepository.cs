using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.SettingsReader;
using System.Linq;

namespace Lykke.Ico.Core.Repositories.EmailHistory
{
    public class InvestorEmailRepository : IInvestorEmailRepository
    {
        private readonly INoSQLTableStorage<InvestorEmailEntity> _table;
        private static string GetPartitionKey(string email) => email;
        private static string GetRowKey() => DateTime.UtcNow.ToString("o");

        public InvestorEmailRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _table = AzureTableStorage<InvestorEmailEntity>.Create(connectionStringManager, "EmailHistory", log);
        }

        public async Task<IEnumerable<IInvestorEmail>> GetAsync(string email)
        {
            return await _table.GetDataAsync(GetPartitionKey(email));
        }

        public async Task SaveAsync(string type, string email, string subject, string body)
        {
            await _table.InsertAsync(new InvestorEmailEntity
            {
                PartitionKey = GetPartitionKey(email),
                RowKey = GetRowKey(),
                Type = type,
                Subject = subject,
                Body = body
            });
        }

        public async Task RemoveAsync(string email)
        {
            var items = await _table.GetDataAsync(GetPartitionKey(email));
            if (items.Any())
            {
                await _table.DeleteAsync(items);
            }
        }
    }
}
