namespace Lykke.Ico.Core.Queues.Emails
{
    [QueueMessage(QueueName = Consts.Emails.Queues.InvestorNewTransaction)]
    public class InvestorNewTransactionMessage : IInvestorMessage
    {
        public string EmailTo { get; set; }
        public string LinkToSummaryPage { get; set; }
        public string LinkTransactionDetails { get; set; }
        public bool KycRequired { get; set; }
        public string KycLink { get; set; }
        public bool MoreInvestmentRequired { get; set; }
        public decimal MinAmount { get; set; }
        public decimal InvestedAmountUsd { get; set; }
        public decimal InvestedAmountToken { get; set; }
        public decimal TransactionAmountToken { get; set; }
        public decimal TransactionAmountUsd { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal TransactionFee { get; set; }
        public string TransactionAsset { get; set; }
    }
}
