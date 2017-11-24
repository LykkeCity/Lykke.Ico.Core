using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.ProcessedBlock
{
    public interface IProcessedBlockRepository
    {
        Task<int> GetLastProcessedBlockAsync(CurrencyType currencyType, string networkName = null);

        Task SetLastProcessedBlockAsync(int height, CurrencyType currencyType, string networkName = null);
    }
}
