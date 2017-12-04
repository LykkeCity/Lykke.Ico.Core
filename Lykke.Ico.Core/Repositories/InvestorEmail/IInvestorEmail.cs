using System;

namespace Lykke.Ico.Core.Repositories.InvestorEmail
{
    public interface IInvestorEmail
    {
        string Email { get; }

        DateTime WhenUtc { get; }

        string Type { get; }

        string Subject { get; set; }

        string Body { get; set; }
    }
}
