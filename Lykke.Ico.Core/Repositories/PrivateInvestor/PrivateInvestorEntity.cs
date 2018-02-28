﻿using System;
using Lykke.AzureStorage.Tables;
using Lykke.AzureStorage.Tables.Entity.Annotation;
using Lykke.AzureStorage.Tables.Entity.ValueTypesMerging;
using Microsoft.WindowsAzure.Storage.Table;

namespace Lykke.Ico.Core.Repositories.PrivateInvestor
{
    [ValueTypeMergingStrategy(ValueTypeMergingStrategy.UpdateAlways)]
    internal class PrivateInvestorEntity : AzureTableEntity, IPrivateInvestor
    {
        [IgnoreProperty]
        public string Email
        {
            get => RowKey;
        }

        public DateTime UpdatedUtc { get; set; }

        public string KycRequestId { get; set; }

        public DateTime? KycRequestedUtc { get; set; }

        public bool? KycPassed { get; set; }

        public DateTime? KycPassedUtc { get; set; }

        public DateTime? KycManuallyUpdatedUtc { get; set; }

        public string ReferralCode { get; set; }

        public DateTime? ReferralCodeUtc { get; set; }
    }
}
