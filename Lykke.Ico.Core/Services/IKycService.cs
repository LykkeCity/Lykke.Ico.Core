using System.Threading.Tasks;

namespace Lykke.Ico.Core.Services
{
    public interface IKycService
    {
        Task<string> GetKycLink(string email, string kycId);
    }
}
