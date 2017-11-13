namespace Lykke.Ico.Core.Contracts.Emails
{
    public class InvestorConfirmation : EmailMessage
    {
        public string ConfirmationToken { get; set; }
    }
}
