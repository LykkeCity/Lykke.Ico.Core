using Lykke.AzureStorage.Tables;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Lykke.Ico.Core.Repositories.AddressPoolHistory
{
    public class AddressPoolHistoryEntity : AzureTableEntity, IAddressPoolHistoryItem
    {
        [IgnoreProperty]
        public string Email { get => PartitionKey; }

        [IgnoreProperty]
        public DateTime WhenUtc { get => Timestamp.UtcDateTime; }

        public string EthPublicKey { get; set; }

        public string BtcPublicKey { get; set; }
    }
}
