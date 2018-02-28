using AzureStorage;
using AzureStorage.Tables;
using Common.Log;
using Lykke.SettingsReader;
using System;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.CampaignSettings
{
    public class CampaignSettingsRepository : ICampaignSettingsRepository
    {
        private readonly INoSQLTableStorage<CampaignSettingsEntity> _table;
        private static string GetPartitionKey() => "";
        private static string GetRowKey() => "Settings";

        public CampaignSettingsRepository(IReloadingManager<string> connectionStringManager, ILog log)
        {
            _table = AzureTableStorage<CampaignSettingsEntity>.Create(connectionStringManager, "CampaignSettings", log);
        }

        public async Task<ICampaignSettings> GetAsync()
        {
            return await _table.GetDataAsync(GetPartitionKey(), GetRowKey());
        }

        public async Task SaveAsync(ICampaignSettings settings)
        {
            await _table.InsertOrMergeAsync(new CampaignSettingsEntity
            {
                PartitionKey = GetPartitionKey(),
                RowKey = GetRowKey(),
                PreSaleStartDateTimeUtc = settings.PreSaleStartDateTimeUtc,
                PreSaleEndDateTimeUtc = settings.PreSaleEndDateTimeUtc,
                PreSaleTotalTokensAmount = settings.PreSaleTotalTokensAmount,
                CrowdSaleStartDateTimeUtc = settings.CrowdSaleStartDateTimeUtc,
                CrowdSaleEndDateTimeUtc = settings.CrowdSaleEndDateTimeUtc,
                CrowdSaleTotalTokensAmount = settings.CrowdSaleTotalTokensAmount,
                MinInvestAmountUsd = settings.MinInvestAmountUsd,
                HardCapUsd = settings.HardCapUsd,
                TokenBasePriceUsd = settings.TokenBasePriceUsd,
                TokenDecimals = settings.TokenDecimals,
                KycEnableRequestSending = settings.KycEnableRequestSending,
                KycCampaignId = settings.KycCampaignId,
                KycLinkTemplate = settings.KycLinkTemplate,
                CaptchaEnable = settings.CaptchaEnable,
                EnableCampaignFrontEnd = settings.EnableCampaignFrontEnd,
                EnableReferralProgram = settings.EnableReferralProgram,
                ReferralCodeLength = settings.ReferralCodeLength,
                ReferralDiscount = settings.ReferralDiscount,
                ReferralOwnerDiscount = settings.ReferralOwnerDiscount,
                UpdatedUtc = DateTime.UtcNow
            });
        }
    }
}
