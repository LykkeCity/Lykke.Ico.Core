﻿using System;

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

        decimal HardCapUsd { get; set; }

        bool KycEnableRequestSending { get; set; }

        string KycCampaignId { get; set; }

        string KycLinkTemplate { get; set; }

        bool CaptchaEnable { get; set; }

        bool EnableCampaignFrontEnd { get; set; }

        bool EnableReferralProgram { get; set; }

        int? ReferralCodeLength { get; set; }

        decimal? ReferralOwnerDiscount { get; set; }

        decimal? ReferralDiscount { get; set; }
    }
}
