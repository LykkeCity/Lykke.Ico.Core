﻿using System;

namespace Lykke.Ico.Core.Queues.Emails
{
    public class InvestorConfirmationMessage : IInvestorMessage
    {
        public string EmailTo { get; set; }
        public Guid ConfirmationToken { get; set; }

        public static InvestorConfirmationMessage Create(string email, Guid confirmationToken)
        {
            return new InvestorConfirmationMessage
            {
                EmailTo = email,
                ConfirmationToken = confirmationToken
            };
        }
    }
}
