namespace Lykke.Ico.Core.Queues.Emails
{
    [QueueMessage(QueueName = Consts.Emails.Queues.InvestorKycReminder)]
    public class InvestorKycReminderMessage : IInvestorMessage
    {
        public string EmailTo { get; set; }
        public string LinkToSummaryPage { get; set; }
    }
}
