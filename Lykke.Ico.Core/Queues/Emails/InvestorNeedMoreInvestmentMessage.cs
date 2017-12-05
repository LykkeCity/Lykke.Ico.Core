namespace Lykke.Ico.Core.Queues.Emails
{
    [QueueMessage(QueueName = Consts.Emails.Queues.InvestorNeedMoreInvestment)]
    public class InvestorNeedMoreInvestmentMessage : IInvestorMessage
    {
        public string EmailTo { get; set; }
        public decimal MinAmount { get; set; }
        public decimal InvestedAmount { get; set; }

        public static InvestorNeedMoreInvestmentMessage Create(string email, decimal minAmount, decimal investedAmount)
        {
            return new InvestorNeedMoreInvestmentMessage
            {
                EmailTo = email,
                MinAmount = minAmount,
                InvestedAmount = investedAmount
            };
        }
    }
}
