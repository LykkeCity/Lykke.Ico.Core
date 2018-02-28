using System;

namespace Lykke.Ico.Core.Repositories.PrivateInvestor
{
    public interface IPrivateInvestor
    {
        string Email { get; }

        DateTime UpdatedUtc { get; set; }

        string KycRequestId { get; set; }

        DateTime? KycRequestedUtc { get; set; }

        bool? KycPassed { get; set; }

        DateTime? KycPassedUtc { get; set; }

        DateTime? KycManuallyUpdatedUtc { get; set; }

        string ReferralCode { get; set; }

        DateTime? ReferralCodeUtc { get; set; }
    }
}
