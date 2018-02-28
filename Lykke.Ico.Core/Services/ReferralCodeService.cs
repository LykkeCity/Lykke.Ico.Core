using Lykke.Ico.Core.Helpers;
using Lykke.Ico.Core.Repositories.InvestorAttribute;
using Lykke.Ico.Core.Repositories.PrivateInvestorAttribute;
using System;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Services
{
    public class ReferralCodeService : IReferralCodeService
    {
        private readonly IInvestorAttributeRepository _investorAttributeRepository;
        private readonly IPrivateInvestorAttributeRepository _privateInvestorAttributeRepository;

        public ReferralCodeService(IInvestorAttributeRepository investorAttributeRepository,
            IPrivateInvestorAttributeRepository privateInvestorAttributeRepository)
        {
            _investorAttributeRepository = investorAttributeRepository;
            _privateInvestorAttributeRepository = privateInvestorAttributeRepository;
        }

        public async Task<string> GetReferralCode(int referralCodeLength)
        {
            var maxAttempts = 1000;
            var counter = 0;

            while (counter < maxAttempts)
            {
                var code = ReferralCodeHelper.Generate(referralCodeLength);

                var email = await _investorAttributeRepository.GetInvestorEmailAsync(
                    InvestorAttributeType.ReferralCode, code);
                if (string.IsNullOrEmpty(email))
                {
                    email = await _privateInvestorAttributeRepository.GetInvestorEmailAsync(
                        PrivateInvestorAttributeType.ReferralCode, code);
                    if (string.IsNullOrEmpty(email))
                    {
                        return code;
                    }
                }

                counter++;
            }

            throw new Exception("Failed to get referral code. Max attempts increased");
        }

        public async Task<string> GetReferralEmail(string code)
        {
            var email = await _investorAttributeRepository.GetInvestorEmailAsync(
                InvestorAttributeType.ReferralCode, code);
            if (!string.IsNullOrEmpty(email))
            {
                return email;
            }

            var privateEmail = await _privateInvestorAttributeRepository.GetInvestorEmailAsync(
                PrivateInvestorAttributeType.ReferralCode, code);
            if (!string.IsNullOrEmpty(privateEmail))
            {
                return privateEmail;
            }

            return null;
        }
    }
}
