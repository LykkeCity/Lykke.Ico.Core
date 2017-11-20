using Lykke.Ico.Core.Contracts.Repositories;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Lykke.Ico.Core.Repositories.InvestorToken
{
    internal class InvestorConfirmationEntity : TableEntity, IInvestorConfirmation
    {
        public string Email { get; set; }

        public Guid ConfirmationToken { get; set; }

        public string IpAddress { get; set; }

        public DateTime? ConfirmationDateTime { get; set; }

        public static InvestorConfirmationEntity Create(string email, string ipAddress)
        {
            return new InvestorConfirmationEntity
            {
                Email = email,
                IpAddress = ipAddress,
                ConfirmationToken = Guid.NewGuid()
            };
        }
    }
}
