using System;
using System.Threading.Tasks;
using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.SettingsReader;

namespace Lykke.Ico.Core.Repositories.ProcessedBlock
{
    public class ProcessedBlockRepository : IProcessedBlockRepository
    {
        private readonly INoSQLTableStorage<ProcessedBlockEntity> _tableStorage;
        private static string GetPartitionKey(CurrencyType currencyType) => Enum.GetName(typeof(CurrencyType), currencyType);
        private static string GetRowKey(string networkName) => networkName ?? "Main";

        public ProcessedBlockRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _tableStorage = AzureTableStorage<ProcessedBlockEntity>.Create(connectionStringManager, "ProcessedBlocks", log);
        }

        public async Task<UInt64> GetLastProcessedBlockAsync(CurrencyType currencyType, string networkName = null)
        {
            var partitionKey = GetPartitionKey(currencyType);
            var rowKey = GetRowKey(networkName);
            var entity = await _tableStorage.GetDataAsync(partitionKey, rowKey);

            if (entity != null)
                return entity.Height;
            else
                return 0;
        }

        public async Task SetLastProcessedBlockAsync(UInt64 height, CurrencyType currencyType, string networkName = null)
        {
            await _tableStorage.InsertOrReplaceAsync(new ProcessedBlockEntity
            {
                Height = height,
                PartitionKey = GetPartitionKey(currencyType),
                RowKey = GetRowKey(networkName)
            });
        }
    }
}
