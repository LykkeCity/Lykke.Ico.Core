using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Ico.Core.Repositories.CampaignSettings
{
    public static class CampaignSettingsExtenstions
    {
        public static int GetTotalTokensAmount(this ICampaignSettings self)
        {
            return self.PreSaleTotalTokensAmount + self.CrowdSaleTotalTokensAmount;
        }
    }
}
