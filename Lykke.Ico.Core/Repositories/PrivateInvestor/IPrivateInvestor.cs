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
    }
}
