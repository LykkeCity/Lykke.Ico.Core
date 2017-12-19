using Lykke.Ico.Core.Repositories.CampaignSettings;
using System;

namespace Lykke.Ico.Core.Helpers
{
    public class TokenInfoHelper
    {
        public static TokenInfo GetTokenInfo(ICampaignSettings campaignSettings, decimal soldTokens, 
            DateTime txDateTimeUtc)
        {
            var isPreSale = campaignSettings.IsPreSale(txDateTimeUtc);
            var isIsCrowdSale = campaignSettings.IsCrowdSale(txDateTimeUtc);

            if (isPreSale)
            {
                return new TokenInfo
                {
                    Price = campaignSettings.GetTokenPrice(TokenPricePhase.PreSale),
                    Phase = TokenPricePhase.PreSale
                };
            }

            if (isIsCrowdSale)
            {
                if (soldTokens < Consts.CrowdSale.InitialAmount)
                {
                    return new TokenInfo
                    {
                        Price = campaignSettings.GetTokenPrice(TokenPricePhase.CrowdSaleInitial),
                        Phase = TokenPricePhase.CrowdSaleInitial
                    };
                }

                var timeSpan = txDateTimeUtc - campaignSettings.CrowdSaleStartDateTimeUtc;
                if (timeSpan < TimeSpan.FromDays(1))
                {
                    return new TokenInfo
                    {
                        Price = campaignSettings.GetTokenPrice(TokenPricePhase.CrowdSaleFirstDay),
                        Phase = TokenPricePhase.CrowdSaleFirstDay
                    };
                }
                else if (timeSpan < TimeSpan.FromDays(7))
                {
                    return new TokenInfo
                    {
                        Price = campaignSettings.GetTokenPrice(TokenPricePhase.CrowdSaleFirstWeek),
                        Phase = TokenPricePhase.CrowdSaleFirstWeek
                    };
                }
                else if (timeSpan < TimeSpan.FromDays(7 * 2))
                {
                    return new TokenInfo
                    {
                        Price = campaignSettings.GetTokenPrice(TokenPricePhase.CrowdSaleSecondWeek),
                        Phase = TokenPricePhase.CrowdSaleSecondWeek
                    };
                }
                else
                {
                    return new TokenInfo
                    {
                        Price = campaignSettings.GetTokenPrice(TokenPricePhase.CrowdSaleLastWeek),
                        Phase = TokenPricePhase.CrowdSaleLastWeek
                    };
                }
            }

            return null;
        }
    }
}
