namespace Lykke.Ico.Core.Contracts.Emails
{
    public class InvestorKycRequest : EmailMessage
    {
        public string KycId { get; set; }
    }
}
