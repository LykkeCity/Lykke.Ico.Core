using System;

namespace Lykke.Ico.Core.Contracts.Repositories
{
    public interface IInvestorConfirmation
    {
        string Email { get; set; }

        Guid ConfirmationToken { get; set; }

        string IpAddress { get; set; }

        DateTime? ConfirmationDateTime { get; set; }
   }
}
