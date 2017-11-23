using Lykke.AzureStorage.Tables;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Ico.Core.Repositories.EmailHistory
{
    public class EmailHistoryEntity : AzureTableEntity, IEmailHistoryItem
    {
        [IgnoreProperty]
        public string Email { get => PartitionKey; }

        public string Type { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
