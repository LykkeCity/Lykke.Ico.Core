using Lykke.Ico.Core.Repositories.CampaignSettings;
using System;

namespace Lykke.Ico.Core.Helpers
{
    public class TokenInfoHelper
    {
        public static TokenInfo GetCurrentTokenInfo(ICampaignSettings campaignSettings, decimal soldTokens, 
            DateTime txDateTimeUtc)
        {
            var isPreSale = campaignSettings.IsPreSale(txDateTimeUtc);
            var isIsCrowdSale = campaignSettings.IsCrowdSale(txDateTimeUtc);

            if (isPreSale)
            {
                return new TokenInfo
                {
                    Price = campaignSettings.TokenBasePriceUsd * 0.75M,
                    Phase = TokenPricePhase.PreSale
                };
            }

            if (isIsCrowdSale)
            {
                if (soldTokens < 20_000_000M)
                {
                    return new TokenInfo
                    {
                        Price = campaignSettings.TokenBasePriceUsd * 0.75M,
                        Phase = TokenPricePhase.CrowdSaleFirst20_000_000
                    };
                }

                var timeSpan = txDateTimeUtc - campaignSettings.CrowdSaleStartDateTimeUtc;
                if (timeSpan < TimeSpan.FromDays(1))
                {
                    return new TokenInfo
                    {
                        Price = campaignSettings.TokenBasePriceUsd * 0.80M,
                        Phase = TokenPricePhase.CrowdSaleFirstDay
                    };
                }
                else if (timeSpan < TimeSpan.FromDays(7))
                {
                    return new TokenInfo
                    {
                        Price = campaignSettings.TokenBasePriceUsd * 0.85M,
                        Phase = TokenPricePhase.CrowdSaleFirstWeek
                    };
                }
                else if (timeSpan < TimeSpan.FromDays(7 * 2))
                {
                    return new TokenInfo
                    {
                        Price = campaignSettings.TokenBasePriceUsd * 0.90M,
                        Phase = TokenPricePhase.CrowdSaleSecondWeek
                    };
                }
                else
                {
                    return new TokenInfo
                    {
                        Price = campaignSettings.TokenBasePriceUsd,
                        Phase = TokenPricePhase.CrowdSaleLastWeek
                    };
                }
            }

            return null;
        }
    }
}
