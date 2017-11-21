using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.Campaign
{
    public interface ICampaignRepository
    {
        Task<decimal> GetTotalRaisedAsync();
        Task SaveAsync(decimal totalRaised);
    }
}
