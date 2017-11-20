using System;

namespace Lykke.Ico.Core.Contracts.Repositories
{
    public interface IInvestor
    {
        string Email { get; set; }

        string TokenAddress { get; set; }

        string RefundEthAddress { get; set; }

        string RefundBtcAddress { get; set; }

        string PayInEthPublicKey { get; set; }

        string PayInEthAddress { get; set; }

        string PayInBtcPublicKey { get; set; }

        string PayInBtcAddress { get; set; }

        DateTime Updated { get; set; }
    }
}
