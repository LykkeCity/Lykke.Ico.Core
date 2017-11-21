using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.Campaign
{
    public interface ICampaignRepository
    {
        Task<decimal> GetTotalRaisedAsync();
        Task<decimal> IncreaseTotalRaisedAsync(decimal increment);
        Task SaveAsync(decimal totalRaised);
    }
}
