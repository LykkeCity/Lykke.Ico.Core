namespace Lykke.Ico.Core.Contracts.Emails
{
    public class InvestorKycRequest : IEmailMessage
    {
        public string EmailTo { get; set; }
        public int Attempts { get; set; }
        public string KycId { get; set; }
    }
}
