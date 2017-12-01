using Microsoft.WindowsAzure.Storage.Table;
using System;
using Lykke.AzureStorage.Tables.Entity.Annotation;
using Lykke.AzureStorage.Tables.Entity.ValueTypesMerging;

namespace Lykke.Ico.Core.Repositories.Investor
{
    [ValueTypeMergingStrategy(ValueTypeMergingStrategy.UpdateAlways)]
    internal class InvestorEntity : TableEntity, IInvestor
    {
        public string Email { get; set; }

        public string TokenAddress { get; set; }

        public string PayInEthPublicKey { get; set; }

        public string PayInEthAddress { get; set; }

        public string PayInBtcPublicKey { get; set; }

        public string PayInBtcAddress { get; set; }

        public string RefundEthAddress { get; set; }

        public string RefundBtcAddress { get; set; }

        public DateTime UpdatedUtc { get; set; }

        public Guid? ConfirmationToken { get; set; }

        public DateTime? ConfirmationDateTimeUtc { get; set; }

        public string KycProcessId { get; set; }

        public string KycResult { get; set; }

        public bool? KycSucceeded { get; set; }

        public decimal AmountBtc { get; set; }

        public decimal AmountEth { get; set; }

        public decimal AmountUsd { get; set; }

        public decimal AmountVld { get; set; }

        public static InvestorEntity Create(string email, Guid confirmationToken)
        {
            return new InvestorEntity
            {
                Email = email,
                ConfirmationToken = confirmationToken,
                ConfirmationDateTimeUtc = DateTime.UtcNow,
                UpdatedUtc = DateTime.UtcNow
            };
        }
    }
}
