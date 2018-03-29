namespace Lykke.Ico.Core.Queues.Emails
{
    [QueueMessage(QueueName = Consts.Emails.Queues.Investor20MFix)]
    public class Investor20MFixMessage : IInvestorMessage
    {
        public string EmailTo { get; set; }
        public string ReferralCode { get; set; }
        public string LinkToSummaryPage { get; set; }
        public decimal OldTokens { get; set; }
        public decimal NewTokens { get; set; }
    }
}
