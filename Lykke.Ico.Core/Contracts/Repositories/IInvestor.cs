using System;

namespace Lykke.Ico.Core.Contracts.Repositories
{
    public interface IInvestor
    {
        string Email { get; set; }

        string TokenAddress { get; set; }

        string PayInEthPublicKey { get; set; }

        string PayInBtcPublicKey { get; set; }

        string RefundEthAddress { get; set; }

        string RefundBtcAddress { get; set; }

        DateTime CreationDateTime { get; set; }

        string IpAddress { get; set; }

        Guid ConfirmationToken { get; set; }
    }
}
