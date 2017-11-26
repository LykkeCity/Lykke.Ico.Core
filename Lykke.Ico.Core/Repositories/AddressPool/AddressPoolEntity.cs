using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Lykke.Ico.Core.Repositories.AddressPool
{
    public class AddressPoolEntity : TableEntity, IAddressPoolItem
    {
        [IgnoreProperty]
        public int Id { get => Int32.Parse(RowKey.TrimStart(new char[] { '0' })); }

        public string EthPublicKey { get; set; }

        public string BtcPublicKey { get; set; }
    }
}
