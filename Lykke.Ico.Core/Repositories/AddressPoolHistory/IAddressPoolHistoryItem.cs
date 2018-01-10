using System;

namespace Lykke.Ico.Core.Repositories.AddressPoolHistory
{
    public interface IAddressPoolHistoryItem
    {
        int Id { get; }

        string Email { get; }

        DateTime CreatedUtc { get; }

        string EthPublicKey { get; set; }

        string BtcPublicKey { get; set; }
    }
}
