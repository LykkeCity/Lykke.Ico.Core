using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Ico.Core.Repositories.AddressPool
{
    public class AddressPoolEntity : TableEntity, IAddressPoolItem
    {
        public string EthPublicKey { get; set; }
        public string BtcPublicKey { get; set; }
    }
}
