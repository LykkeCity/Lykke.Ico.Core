namespace Lykke.Ico.Core.Queues.Emails
{
    [QueueMessage(QueueName = Consts.Emails.Queues.InvestorSummary)]
    public class InvestorSummaryMessage : IInvestorMessage
    {
        public string EmailTo { get; set; }
        public string LinkToSummaryPage { get; set; }
        public string TokenAddress { get; set; }
        public string RefundBtcAddress { get; set; }
        public string RefundEthAddress { get; set; }
        public string LinkEthAddress { get; set; }
        public string LinkBtcAddress { get; set; }
    }
}   
