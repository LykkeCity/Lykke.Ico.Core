namespace Lykke.Ico.Core.Queues.Emails
{
    public class InvestorNewTransactionMessage : IInvestorMessage
    {
        public string EmailTo { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public string Amount { get; set; }

        public static InvestorNewTransactionMessage Create(string email, CurrencyType currencyType, string amount)
        {
            return new InvestorNewTransactionMessage
            {
                EmailTo = email,
                CurrencyType = currencyType,
                Amount = amount
            };
        }
    }
}
