using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.Investment
{
    public interface IInvestmentRepository
    {
        Task<IEnumerable<IInvestment>> GetInvestmentsAsync(string investorEmail);
        Task SaveAsync(string investorEmail, string txHash, uint outputIndex, CurrencyType currencyType, decimal amount, decimal amountUsd);
    }
}