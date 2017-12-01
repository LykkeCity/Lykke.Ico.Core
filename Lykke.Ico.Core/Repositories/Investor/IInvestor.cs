using System;

namespace Lykke.Ico.Core.Repositories.Investor
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

        DateTime UpdatedUtc { get; set; }

        Guid? ConfirmationToken { get; set; }

        DateTime? ConfirmationDateTimeUtc { get; set; }

        string KycProcessId { get; set; }

        string KycResult { get; set; }

        bool? KycSucceeded { get; set; }

        decimal AmountBtc { get; set; }

        decimal AmountEth { get; set; }

        decimal AmountUsd { get; set; }

        decimal AmountVld { get; set; }
    }
}
