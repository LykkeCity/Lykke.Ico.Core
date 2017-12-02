using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.CryptoInvestment
{
    public interface ICryptoInvestmentRepository
    {
        Task<ICryptoInvestment> GetAsync(string email, string transactionId);

        Task<IEnumerable<ICryptoInvestment>> GetByEmailAsync(string email);

        Task SaveAsync(ICryptoInvestment entity);

        Task RemoveAsync(string email);
    }
}
