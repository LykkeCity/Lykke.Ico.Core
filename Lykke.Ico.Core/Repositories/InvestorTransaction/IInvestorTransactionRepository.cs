using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.InvestorTransaction
{ 
    public interface IInvestorTransactionRepository
    {
        Task<IInvestorTransaction> GetAsync(string email, string uniqueId);

        Task<IEnumerable<IInvestorTransaction>> GetByEmailAsync(string email);

        Task SaveAsync(IInvestorTransaction tx);

        Task RemoveAsync(string email);
    }
}
