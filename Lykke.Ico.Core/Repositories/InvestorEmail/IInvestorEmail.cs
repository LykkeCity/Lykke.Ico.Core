using System;

namespace Lykke.Ico.Core.Repositories.EmailHistory
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
