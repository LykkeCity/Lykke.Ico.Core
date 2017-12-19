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

        public static TokenInfo GetTokenInfo(this ICampaignSettings self, decimal soldTokens, DateTime txDateTimeUtc)
        {
            var isPreSale = self.IsPreSale(txDateTimeUtc);
            var isIsCrowdSale = self.IsCrowdSale(txDateTimeUtc);

            if (isPreSale)
            {
                return new TokenInfo
                {
                    Price = self.GetTokenPrice(TokenPricePhase.PreSale),
                    Phase = TokenPricePhase.PreSale
                };
            }

            if (isIsCrowdSale)
            {
                if (soldTokens < Consts.CrowdSale.InitialAmount)
                {
                    return new TokenInfo
                    {
                        Price = self.GetTokenPrice(TokenPricePhase.CrowdSaleInitial),
                        Phase = TokenPricePhase.CrowdSaleInitial
                    };
                }

                var timeSpan = txDateTimeUtc - self.CrowdSaleStartDateTimeUtc;
                if (timeSpan < TimeSpan.FromDays(1))
                {
                    return new TokenInfo
                    {
                        Price = self.GetTokenPrice(TokenPricePhase.CrowdSaleFirstDay),
                        Phase = TokenPricePhase.CrowdSaleFirstDay
                    };
                }
                else if (timeSpan < TimeSpan.FromDays(7))
                {
                    return new TokenInfo
                    {
                        Price = self.GetTokenPrice(TokenPricePhase.CrowdSaleFirstWeek),
                        Phase = TokenPricePhase.CrowdSaleFirstWeek
                    };
                }
                else if (timeSpan < TimeSpan.FromDays(7 * 2))
                {
                    return new TokenInfo
                    {
                        Price = self.GetTokenPrice(TokenPricePhase.CrowdSaleSecondWeek),
                        Phase = TokenPricePhase.CrowdSaleSecondWeek
                    };
                }
                else
                {
                    return new TokenInfo
                    {
                        Price = self.GetTokenPrice(TokenPricePhase.CrowdSaleLastWeek),
                        Phase = TokenPricePhase.CrowdSaleLastWeek
                    };
                }
            }

            return null;
        }
    }
}
