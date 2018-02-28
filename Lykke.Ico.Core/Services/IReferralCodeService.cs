using System.Threading.Tasks;

namespace Lykke.Ico.Core.Services
{
    public interface IReferralCodeService
    {
        Task<string> GetReferralCode(int referralCodeLength);
    }
}