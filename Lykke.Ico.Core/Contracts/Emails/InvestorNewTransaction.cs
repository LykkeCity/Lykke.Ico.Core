namespace Lykke.Ico.Core.Contracts.Emails
{
    public class InvestorNewTransaction : IEmailMessage
    {
        public string EmailTo { get; set; }
        public int Attempts { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public string Amount { get; set; }
        public string TokensAmount { get; set; }
    }
}
