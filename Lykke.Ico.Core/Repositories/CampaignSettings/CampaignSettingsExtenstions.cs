using System;

namespace Lykke.Ico.Core.Repositories.CampaignSettings
{
    public static class CampaignSettingsExtenstions
    {
        public static int GetTotalTokensAmount(this ICampaignSettings self)
        {
            return self.PreSaleTotalTokensAmount + self.CrowdSaleTotalTokensAmount;
        }

        public static bool IsPreSale(this ICampaignSettings self, DateTime txCreatedUtc)
        {
            return txCreatedUtc >= self.PreSaleStartDateTimeUtc && txCreatedUtc <= self.PreSaleEndDateTimeUtc;
        }

        public static bool IsCrowdSale(this ICampaignSettings self, DateTime txCreatedUtc)
        {
            return txCreatedUtc >= self.CrowdSaleStartDateTimeUtc && txCreatedUtc <= self.CrowdSaleEndDateTimeUtc;
        }
    }
}
