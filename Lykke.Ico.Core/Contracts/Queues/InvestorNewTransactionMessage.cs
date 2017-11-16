namespace Lykke.Ico.Core.Contracts.Queues
{
    public class InvestorNewTransactionMessage : IInvestorMessage
    {
        public string EmailTo { get; set; }
        public int Attempts { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public string Amount { get; set; }

        public static InvestorNewTransactionMessage Create(string email, CurrencyType currencyType, string amount)
        {
            return new InvestorNewTransactionMessage
            {
                EmailTo = email,
                Attempts = 0,
                CurrencyType = currencyType,
                Amount = amount
            };
        }
    }
}
