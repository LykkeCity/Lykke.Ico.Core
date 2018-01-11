using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.PrivateInvestorAttribute
{
    public interface IPrivateInvestorAttributeRepository
    {
        Task<string> GetInvestorEmailAsync(PrivateInvestorAttributeType type, string value);
        Task RemoveAsync(PrivateInvestorAttributeType type, string email);
        Task SaveAsync(PrivateInvestorAttributeType type, string email, string value);
    }
}
