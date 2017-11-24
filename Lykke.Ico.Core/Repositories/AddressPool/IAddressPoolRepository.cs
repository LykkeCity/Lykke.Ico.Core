using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.AddressPool
{
    public interface IAddressPoolRepository
    {
        Task AddAsync(string ethPulicKey, string btcPublicKey);

        Task AddBatchAsync(List<IAddressPoolItem> keys);

        IAddressPoolItem GetNextFree(string email);
    }
}
