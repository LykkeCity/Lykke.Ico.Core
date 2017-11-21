using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Lykke.Ico.Core.Repositories.Investor
{
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

        public DateTime Updated { get; set; }

        public Guid? ConfirmationToken { get; set; }

        public DateTime? ConfirmationDateTime { get; set; }

        public static InvestorEntity Create(string email, Guid confirmationToken)
        {
            return new InvestorEntity
            {
                Email = email,
                ConfirmationToken = confirmationToken,
                ConfirmationDateTime = DateTime.Now,
                Updated = DateTime.Now
            };
        }
    }
}
