using Lykke.Ico.Core.Contracts.Repositories;
using System;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.InvestorToken
{
    public interface IInvestorConfirmationRepository
    {
        Task<IInvestorConfirmation> GetAsync(Guid confirmationToken);

        Task<IInvestorConfirmation> GetAsync(string email);

        Task<IInvestorConfirmation> AddAsync(string email, string ipAddress);

        Task ConfirmAsync(Guid confirmationToken);
    }
}
