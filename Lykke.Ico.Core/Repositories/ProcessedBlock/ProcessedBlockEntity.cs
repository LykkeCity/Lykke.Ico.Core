using Lykke.AzureStorage.Tables;

namespace Lykke.Ico.Core.Repositories.ProcessedBlock
{
    internal class ProcessedBlockEntity : AzureTableEntity
    {
        public int Height { get; set; }
    }
}
