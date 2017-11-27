using System;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.ProcessedBlock
{
    public interface IProcessedBlockRepository
    {
        Task<UInt64> GetLastProcessedBlockAsync(CurrencyType currencyType, string networkName = null);

        Task SetLastProcessedBlockAsync(UInt64 height, CurrencyType currencyType, string networkName = null);
    }
}
