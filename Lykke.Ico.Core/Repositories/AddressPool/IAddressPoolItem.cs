namespace Lykke.Ico.Core.Repositories.AddressPool
{
    public interface IAddressPoolItem
    {
        string EthPublicKey { get; set; }
        string BtcPublicKey { get; set; }
    }
}
