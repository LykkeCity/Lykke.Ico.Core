namespace Lykke.Ico.Core.Queues.Emails
{
    [QueueMessage(QueueName = Consts.Emails.Queues.InvestorKycNotification)]
    public class InvestorKycNotificationMessage
    {
        public string EmailTo { get; set; }
        public string LinkToSummaryPage { get; set; }
    }
}
