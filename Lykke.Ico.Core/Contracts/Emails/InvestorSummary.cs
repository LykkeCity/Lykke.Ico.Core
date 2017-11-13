namespace Lykke.Ico.Core.Contracts.Emails
{
    public class InvestorSummary : EmailMessage
    {
        public string BtcAddress { get; set; }
        public string EthAddress { get; set; }
    }
}
