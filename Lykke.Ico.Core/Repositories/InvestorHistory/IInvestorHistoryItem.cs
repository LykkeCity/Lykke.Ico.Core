using System;

namespace Lykke.Ico.Core.Repositories.InvestorHistory
{
    public interface IInvestorHistoryItem
    {
        string Email { get; }

        DateTime WhenUtc { get; }

        InvestorHistoryAction Action { get; set; }

        string Json { get; set; }
    }
}
