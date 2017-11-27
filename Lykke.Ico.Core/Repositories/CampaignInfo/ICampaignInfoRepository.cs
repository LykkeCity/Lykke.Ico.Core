using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.CampaignInfo
{
    public interface ICampaignInfoRepository
    {
        Task<Dictionary<string, string>> GetAllAsync();
        Task<string> GetValueAsync(CampaignInfoType type);
        Task SaveValueAsync(CampaignInfoType type, string value);
        void IncrementValue(CampaignInfoType type, double value);
        void IncrementValue(CampaignInfoType type, int value);
        void IncrementValue(CampaignInfoType type, decimal value);
        void IncrementValue(CampaignInfoType type, ulong value);
    }
}
