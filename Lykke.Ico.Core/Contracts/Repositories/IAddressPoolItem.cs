namespace Lykke.Ico.Core.Contracts.Repositories
{
    public interface IAddressPoolItem
    {
        string EthPublicKey { get; set; }
        string BtcPublicKey { get; set; }
    }
}
