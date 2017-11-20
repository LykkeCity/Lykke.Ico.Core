using System.Threading.Tasks;
using Lykke.Ico.Core.Contracts.Repositories;

namespace Lykke.Ico.Core.Repositories.AddressPool
{
    public interface IAddressPoolRepository
    {
        Task<IAddressPoolItem> AddAsync(string ethPulicKey, string btcPublicKey);
        Task<IAddressPoolItem> GetNextFreeAsync();
    }
}