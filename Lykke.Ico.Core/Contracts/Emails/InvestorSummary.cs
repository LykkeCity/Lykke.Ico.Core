namespace Lykke.Ico.Core.Contracts.Emails
{
    public class InvestorSummary : IEmailMessage
    {
        public string EmailTo { get; set; }
        public int Attempts { get; set; }
        public string BtcAddress { get; set; }
        public string EthAddress { get; set; }
    }
}
