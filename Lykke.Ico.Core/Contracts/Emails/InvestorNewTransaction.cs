namespace Lykke.Ico.Core.Contracts.Emails
{
    public class InvestorNewTransaction : EmailMessage
    {
        public CurrencyType CurrencyType { get; set; }
        public string Amount { get; set; }
        public string TokensAmount { get; set; }
    }
}
