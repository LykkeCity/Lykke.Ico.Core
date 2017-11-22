using System;

namespace Lykke.Ico.Core.Queues.Emails
{
    [QueueMessage(QueueName = Consts.Emails.Queues.InvestorConfirmation)]
    public class InvestorConfirmationMessage : IInvestorMessage
    {
        public string EmailTo { get; set; }
        public int Attempts { get; set; }
        public Guid ConfirmationToken { get; set; }

        public static InvestorConfirmationMessage Create(string email, Guid confirmationToken)
        {
            return new InvestorConfirmationMessage
            {
                EmailTo = email,
                Attempts = 0,
                ConfirmationToken = confirmationToken
            };
        }
    }
}
