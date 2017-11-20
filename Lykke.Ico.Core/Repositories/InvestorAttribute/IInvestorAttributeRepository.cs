using Lykke.Ico.Core.Contracts.Repositories;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.InvestorAttribute
{
    public interface IInvestorAttributeRepository
    {
        Task<string> GetInvestorEmailAsync(InvestorAttributeType type, string value);

        Task SaveAsync(InvestorAttributeType type, string email, string value);
    }
}
