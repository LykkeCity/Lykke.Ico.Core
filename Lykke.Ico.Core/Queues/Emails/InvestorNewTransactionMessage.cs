namespace Lykke.Ico.Core.Queues.Emails
{
    [QueueMessage(QueueName = Consts.Emails.Queues.InvestorNewTransaction)]
    public class InvestorNewTransactionMessage : IInvestorMessage
    {
        public string EmailTo { get; set; }
        public string Payment { get; set; }
        public string TransactionLink { get; set; }
        public bool KycRequired { get; set; }
        public string KycLink { get; set; }
        public bool MoreInvestmentRequired { get; set; }
        public decimal MinAmount { get; set; }
        public decimal InvestedAmount { get; set; }
    }
}
