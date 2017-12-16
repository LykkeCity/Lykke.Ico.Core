using System;

namespace Lykke.Ico.Core.Repositories.CampaignSettings
{
    public interface ICampaignSettings
    {
        DateTime PreSaleStartDateTimeUtc { get; set; }

        DateTime PreSaleEndDateTimeUtc { get; set; }

        int PreSaleTotalTokensAmount { get; set; }

        DateTime CrowdSaleStartDateTimeUtc { get; set; }

        DateTime CrowdSaleEndDateTimeUtc { get; set; }

        int CrowdSaleTotalTokensAmount { get; set; }

        decimal TokenBasePriceUsd { get; set; }

        int TokenDecimals { get; set; }

        decimal MinInvestAmountUsd { get; set; }

        int TotalTokensAmount { get; }
    }
}
