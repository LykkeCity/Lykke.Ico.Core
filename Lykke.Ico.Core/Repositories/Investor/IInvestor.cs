using System;

namespace Lykke.Ico.Core.Repositories.Investor
{
    public interface IInvestor
    {
        string Email { get; }

        string TokenAddress { get; set; }

        string RefundEthAddress { get; set; }

        string RefundBtcAddress { get; set; }

        string PayInEthPublicKey { get; set; }

        string PayInEthAddress { get; set; }

        string PayInBtcPublicKey { get; set; }

        string PayInBtcAddress { get; set; }

        DateTime UpdatedUtc { get; set; }

        Guid? ConfirmationToken { get; set; }

        DateTime? ConfirmationTokenCreatedUtc { get; set; }

        DateTime? ConfirmedUtc { get; set; }

        string KycRequestId { get; set; }

        DateTime? KycRequestedUtc { get; set; }

        bool? KycPassed { get; set; }

        DateTime? KycPassedUtc { get; set; }

        decimal AmountBtc { get; set; }

        decimal AmountEth { get; set; }

         decimal AmountFiat { get; set; }

        decimal AmountUsd { get; set; }

        decimal AmountToken { get; set; }
    }
}
