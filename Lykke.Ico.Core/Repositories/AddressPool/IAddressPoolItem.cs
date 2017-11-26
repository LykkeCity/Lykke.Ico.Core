namespace Lykke.Ico.Core.Repositories.AddressPool
{
    public interface IAddressPoolItem
    {
        int Id { get; }
        string EthPublicKey { get; set; }
        string BtcPublicKey { get; set; }
    }
}
