namespace Lykke.Ico.Core.Contracts.Emails
{
    public class InvestorConfirmation : IEmailMessage
    {
        public string EmailTo { get; set; }
        public int Attempts { get; set; }
        public string ConfirmationToken { get; set; }
    }
}
