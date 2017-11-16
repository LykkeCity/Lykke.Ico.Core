namespace Lykke.Ico.Core.Contracts.Queues
{
    public class InvestorKycRequestMessage : IInvestorMessage
    {
        public string EmailTo { get; set; }
        public int Attempts { get; set; }
        public string KycId { get; set; }

        public static InvestorKycRequestMessage Create(string email, string kycId)
        {
            return new InvestorKycRequestMessage
            {
                EmailTo = email,
                Attempts = 0,
                KycId = kycId
            };
        }
    }
}
