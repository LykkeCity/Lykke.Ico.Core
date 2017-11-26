namespace Lykke.Ico.Core.Repositories.AddressPool
{
    public class AddressPoolItem : IAddressPoolItem
    {
        public int Id { get; set; }
        public string EthPublicKey { get; set; }
        public string BtcPublicKey { get; set; }
    }
}
