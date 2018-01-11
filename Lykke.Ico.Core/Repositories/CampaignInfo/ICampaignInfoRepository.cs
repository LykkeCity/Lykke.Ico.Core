using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.CampaignInfo
{
    public interface ICampaignInfoRepository
    {
        Task<Dictionary<string, string>> GetAllAsync();
        Task<string> GetValueAsync(CampaignInfoType type);
        Task SaveValueAsync(CampaignInfoType type, string value);
        Task IncrementValue(CampaignInfoType type, double value);
        Task IncrementValue(CampaignInfoType type, int value);
        Task IncrementValue(CampaignInfoType type, decimal value);
        Task IncrementValue(CampaignInfoType type, ulong value);
        Task<List<(string email, string uniqueId)>> GetLatestTransactionsAsync();
        Task SaveLatestTransactionsAsync(string email, string uniqueId);
    }
}
