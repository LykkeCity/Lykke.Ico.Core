namespace Lykke.Ico.Core.Queues.Emails
{
    public class InvestorKycRequestMessage : IInvestorMessage
    {
        public string EmailTo { get; set; }
        public string KycId { get; set; }

        public static InvestorKycRequestMessage Create(string email, string kycId)
        {
            return new InvestorKycRequestMessage
            {
                EmailTo = email,
                KycId = kycId
            };
        }
    }
}
