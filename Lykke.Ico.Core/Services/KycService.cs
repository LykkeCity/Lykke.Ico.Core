using Common;
using Lykke.Ico.Core.Repositories.CampaignSettings;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Services
{
    public class KycService : IKycService
    {
        private readonly ICampaignSettingsRepository _campaignSettingsRepository;
        private readonly IUrlEncryptionService _urlEncryptionService;

        public KycService(ICampaignSettingsRepository campaignSettingsRepository,
            IUrlEncryptionService urlEncryptionService)
        {
            _campaignSettingsRepository = campaignSettingsRepository;
            _urlEncryptionService = urlEncryptionService;
        }

        public async Task<string> GetKycLink(string email, string kycId)
        {
            var settings = await _campaignSettingsRepository.GetAsync();
            var kycMessage = new { campaignId = settings.KycCampaignId, email = email, kycId = kycId };
            var kycEncryptedMessage = _urlEncryptionService.Encrypt(kycMessage.ToJson());
            var kycLink = settings.KycLinkTemplate.Replace("{kycEncryptedMessage}", kycEncryptedMessage);

            return kycLink;
        }
    }
}
