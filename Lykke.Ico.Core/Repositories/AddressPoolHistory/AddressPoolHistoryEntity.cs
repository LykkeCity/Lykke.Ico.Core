using Lykke.AzureStorage.Tables;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Lykke.Ico.Core.Repositories.AddressPoolHistory
{
    internal class AddressPoolHistoryEntity : AzureTableEntity, IAddressPoolHistoryItem
    {
        [IgnoreProperty]
        public int Id { get => Int32.Parse(RowKey.TrimStart(new char[] { '0' })); }

        [IgnoreProperty]
        public DateTime CreatedUtc { get => Timestamp.UtcDateTime; }

        public string Email { get; set; }

        public string EthPublicKey { get; set; }

        public string BtcPublicKey { get; set; }
    }
}
