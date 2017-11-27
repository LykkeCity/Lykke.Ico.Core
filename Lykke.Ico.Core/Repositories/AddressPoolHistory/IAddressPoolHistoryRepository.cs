using System.Threading.Tasks;
using System.Collections.Generic;
using Lykke.Ico.Core.Repositories.AddressPool;

namespace Lykke.Ico.Core.Repositories.AddressPoolHistory
{
    public interface IAddressPoolHistoryRepository
    {
        Task<IEnumerable<IAddressPoolHistoryItem>> GetAsync(string email);

        Task RemoveAsync(string email);

        Task SaveAsync(IAddressPoolItem addressPoolItem, string email);
    }
}
