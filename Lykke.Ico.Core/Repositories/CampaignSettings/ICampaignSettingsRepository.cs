using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.CampaignSettings
{
    public interface ICampaignSettingsRepository
    {
        Task<ICampaignSettings> GetAsync(string email);
        Task SaveAsync(ICampaignSettings settings);
    }
}
