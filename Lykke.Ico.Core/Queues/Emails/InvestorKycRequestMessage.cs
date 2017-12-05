namespace Lykke.Ico.Core.Queues.Emails
{
    [QueueMessage(QueueName = Consts.Emails.Queues.InvestorKycRequest)]
    public class InvestorKycRequestMessage : IInvestorMessage
    {
        public string EmailTo { get; set; }
        public string KycId { get; set; }
    }
}
