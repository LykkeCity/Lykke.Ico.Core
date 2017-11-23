namespace Lykke.Ico.Core.Queues.Emails
{
    public interface IInvestorMessage : IMessage
    {
        string EmailTo { get; set; }
    }
}
