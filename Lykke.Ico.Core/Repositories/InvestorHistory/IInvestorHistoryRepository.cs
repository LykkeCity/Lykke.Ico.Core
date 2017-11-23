using Lykke.Ico.Core.Repositories.Investor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.InvestorHistory
{
    public interface IInvestorHistoryRepository
    {
        Task<IEnumerable<IInvestorHistoryItem>> GetAsync(string email);

        Task SaveAsync(IInvestor investor, InvestorHistoryAction action);

        Task RemoveAsync(string email);
    }
}
