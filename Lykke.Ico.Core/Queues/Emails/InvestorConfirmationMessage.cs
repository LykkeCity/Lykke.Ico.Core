using System;

namespace Lykke.Ico.Core.Queues.Emails
{
    [QueueMessage(QueueName = Consts.Emails.Queues.InvestorConfirmation)]
    public class InvestorConfirmationMessage : IInvestorMessage
    {
        public string EmailTo { get; set; }
        public string ConfirmationLink { get; set; }
    }
}
