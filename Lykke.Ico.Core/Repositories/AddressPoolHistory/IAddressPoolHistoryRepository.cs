using System.Threading.Tasks;
using Lykke.Ico.Core.Repositories.AddressPool;

namespace Lykke.Ico.Core.Repositories.AddressPoolHistory
{
    public interface IAddressPoolHistoryRepository
    {
        Task<IAddressPoolHistoryItem> GetAsync(string email);

        Task RemoveAsync(string email);

        Task SaveAsync(IAddressPoolItem addressPoolItem, string email);
    }
}
