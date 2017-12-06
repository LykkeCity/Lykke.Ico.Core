using System;

namespace Lykke.Ico.Core.Repositories.CampaignSettings
{
    public interface ICampaignSettings
    {
        DateTime StartDateTimeUtc { get; set; }

        DateTime EndDateTimeUtc { get; set; }

        int TotalTokensAmount { get; set; }

        decimal TokenBasePriceUsd { get; set; }

        int TokenDecimals { get; set; }

        decimal MinInvestAmountUsd { get; set; }
    }
}
