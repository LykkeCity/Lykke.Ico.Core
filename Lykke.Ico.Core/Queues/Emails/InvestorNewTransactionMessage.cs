namespace Lykke.Ico.Core.Queues.Emails
{
    [QueueMessage(QueueName = Consts.Emails.Queues.InvestorNewTransaction)]
    public class InvestorNewTransactionMessage : IInvestorMessage
    {
        public string EmailTo { get; set; }
        public string Payment { get; set; }
        public string TransactionLink { get; set; }

        public static InvestorNewTransactionMessage Create(string emailTo, string payment, string transactionLink)
        {
            return new InvestorNewTransactionMessage
            {
                EmailTo = emailTo,
                Payment = payment,
                TransactionLink = transactionLink
            };
        }
    }
}
