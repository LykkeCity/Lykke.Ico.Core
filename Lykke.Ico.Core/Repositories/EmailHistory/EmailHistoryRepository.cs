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
    public class EmailHistoryRepository : IEmailHistoryRepository
    {
        private readonly INoSQLTableStorage<EmailHistoryEntity> _table;
        private static string GetPartitionKey(string email) => email;
        private static string GetRowKey() => DateTime.Now.ToString();

        public EmailHistoryRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _table = AzureTableStorage<EmailHistoryEntity>.Create(connectionStringManager, "EmailHistory", log);
        }

        public async Task<IEnumerable<IEmailHistoryItem>> GetAsync(string email)
        {
            return await _table.GetDataAsync(GetPartitionKey(email));
        }

        public async Task SaveAsync(string email, string subject, string body)
        {
            await _table.InsertOrReplaceAsync(new EmailHistoryEntity
            {
                PartitionKey = GetPartitionKey(email),
                RowKey = GetRowKey(),
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
