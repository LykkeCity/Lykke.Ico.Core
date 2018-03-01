namespace Lykke.Ico.Core.Queues.Emails
{
    [QueueMessage(QueueName = Consts.Emails.Queues.InvestorReferralCode)]
    public class InvestorReferralCodeMessage : IInvestorMessage
    {
        public string EmailTo { get; set; }
        public string ReferralCode { get; set; }
        public string LinkToSummaryPage { get; set; }
    }
}
