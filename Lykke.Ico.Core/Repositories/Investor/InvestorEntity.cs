using Lykke.Ico.Core.Contracts.Repositories;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Lykke.Ico.Core.Repositories.Investor
{
    internal class InvestorEntity : TableEntity, IInvestor
    {
        public string Email { get; set; }

        public string TokenAddress { get; set; }

        public string PayInEthPublicKey { get; set; }

        public string PayInBtcPublicKey { get; set; }

        public string RefundEthAddress { get; set; }

        public string RefundBtcAddress { get; set; }

        public DateTime CreationDateTime { get; set; }

        public string IpAddress { get; set; }

        public Guid ConfirmationToken { get; set; }

        public static InvestorEntity Create(string email, string ipAddress)
        {
            return new InvestorEntity
            {
                Email = email,
                CreationDateTime = DateTime.Now,
                IpAddress = ipAddress,
                ConfirmationToken = Guid.NewGuid()
            };
        }
    }
}
