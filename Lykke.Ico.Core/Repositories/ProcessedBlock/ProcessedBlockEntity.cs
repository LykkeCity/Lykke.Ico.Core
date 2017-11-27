using System;
using Lykke.AzureStorage.Tables;

namespace Lykke.Ico.Core.Repositories.ProcessedBlock
{
    internal class ProcessedBlockEntity : AzureTableEntity
    {
        public UInt64 Height { get; set; }
    }
}
