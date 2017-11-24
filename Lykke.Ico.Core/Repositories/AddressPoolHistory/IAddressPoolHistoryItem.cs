﻿using System;

namespace Lykke.Ico.Core.Repositories.AddressPoolHistory
{
    public interface IAddressPoolHistoryItem
    {
        string Email { get; }

        DateTime WhenUtc { get; }

        string EthPublicKey { get; set; }

        string BtcPublicKey { get; set; }
    }
}
