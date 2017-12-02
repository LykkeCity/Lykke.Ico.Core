using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.CryptoInvestment
{
    public interface ICryptoInvestmentRepository
    {
        Task<ICryptoInvestment> GetInvestmentAsync(string investorEmail, string transactionId);

        Task<IEnumerable<ICryptoInvestment>> GetInvestmentsAsync(string investorEmail);

        Task SaveAsync(ICryptoInvestment entity);

        Task RemoveAsync(string email);
    }
}
