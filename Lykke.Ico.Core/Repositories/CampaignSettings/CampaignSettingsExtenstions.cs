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

        public static decimal GetTokenPrice(this ICampaignSettings self, TokenPricePhase phase)
        {
            switch (phase)
            {
                case TokenPricePhase.PreSale:
                    return self.TokenBasePriceUsd * 0.75M;
                case TokenPricePhase.CrowdSaleInitial:
                    return self.TokenBasePriceUsd * 0.75M;
                case TokenPricePhase.CrowdSaleFirstDay:
                    return self.TokenBasePriceUsd * 0.80M;
                case TokenPricePhase.CrowdSaleFirstWeek:
                    return self.TokenBasePriceUsd * 0.85M;
                case TokenPricePhase.CrowdSaleSecondWeek:
                    return self.TokenBasePriceUsd * 0.90M;
                case TokenPricePhase.CrowdSaleLastWeek:
                    return self.TokenBasePriceUsd;
                default:
                    throw new ArgumentException($"Not supported phase={Enum.GetName(typeof(TokenPricePhase), phase)}");
            }
        }
    }
}
