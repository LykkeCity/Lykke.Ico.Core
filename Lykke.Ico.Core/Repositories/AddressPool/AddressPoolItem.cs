namespace Lykke.Ico.Core.Repositories.AddressPool
{
    public class AddressPoolItem : IAddressPoolItem
    {
        public string EthPublicKey { get; set; }
        public string BtcPublicKey { get; set; }
    }
}
