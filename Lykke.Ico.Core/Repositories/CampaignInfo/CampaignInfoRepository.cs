﻿using System;
using System.Threading.Tasks;
using AzureStorage;
using AzureStorage.Tables;
using Lykke.SettingsReader;
using Common.Log;
using System.Linq;
using System.Collections.Generic;

namespace Lykke.Ico.Core.Repositories.CampaignInfo
{
    public class CampaignInfoRepository : ICampaignInfoRepository
    {
        private static readonly Object _lock = new Object();
        private readonly INoSQLTableStorage<CampaignInfoEntity> _table;
        private static string GetPartitionKey() => "";
        private static string GetRowKey(CampaignInfoType type) => Enum.GetName(typeof(CampaignInfoType), type);

        public CampaignInfoRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _table = AzureTableStorage<CampaignInfoEntity>.Create(connectionStringManager, "CampaignInfo", log);
        }

        public async Task<Dictionary<string, string>> GetAllAsync()
        {
            var entities = await _table.GetDataAsync(GetPartitionKey());
            if (entities.Any())
            {
                return entities.ToDictionary(x => x.Name, x => x.Value);
            }

            return new Dictionary<string, string>();
        }

        public async Task<string> GetValueAsync(CampaignInfoType type)
        {
            var entity = await _table.GetDataAsync(GetPartitionKey(), GetRowKey(type));

            return entity?.Value;
        }

        public async Task SaveValueAsync(CampaignInfoType type, string value)
        {
            var entity = new CampaignInfoEntity { Value = value };

            entity.PartitionKey = GetPartitionKey();
            entity.RowKey = GetRowKey(type);

            await _table.InsertOrMergeAsync(entity);
        }

        public void IncrementValue(CampaignInfoType type, int value)
        {
            lock (_lock)
            {
                var currentValue = GetValueIntAsync(type).Result;

                SaveValueAsync(type, ((currentValue ?? 0) + value).ToString()).Wait();
            }
        }

        public void IncrementValue(CampaignInfoType type, double value)
        {
            lock (_lock)
            {
                var currentValue = GetValueDoubleAsync(type).Result;

                SaveValueAsync(type, ((currentValue ?? 0) + value).ToString()).Wait();
            }
        }

        public void IncrementValue(CampaignInfoType type, decimal value)
        {
            lock (_lock)
            {
                var currentValue = GetValueDecimalAsync(type).Result;

                SaveValueAsync(type, ((currentValue ?? 0) + value).ToString()).Wait();
            }
        }

        public void IncrementValue(CampaignInfoType type, ulong value)
        {
            lock (_lock)
            {
                var currentValue = GetValueULongAsync(type).Result;

                SaveValueAsync(type, ((currentValue ?? 0) + value).ToString()).Wait();
            }
        }

        private async Task<int?> GetValueIntAsync(CampaignInfoType type)
        {
            var valueStr = await GetValueAsync(type);
            if (string.IsNullOrEmpty(valueStr))
            {
                return null;
            }

            return Int32.Parse(valueStr);
        }

        private async Task<double?> GetValueDoubleAsync(CampaignInfoType type)
        {
            var valueStr = await GetValueAsync(type);
            if (string.IsNullOrEmpty(valueStr))
            {
                return null;
            }

            return Double.Parse(valueStr);
        }

        private async Task<decimal?> GetValueDecimalAsync(CampaignInfoType type)
        {
            var valueStr = await GetValueAsync(type);
            if (string.IsNullOrEmpty(valueStr))
            {
                return null;
            }

            return Decimal.Parse(valueStr);
        }

        private async Task<ulong?> GetValueULongAsync(CampaignInfoType type)
        {
            var valueStr = await GetValueAsync(type);
            if (string.IsNullOrEmpty(valueStr))
            {
                return null;
            }

            return UInt64.Parse(valueStr);
        }
    }
}
