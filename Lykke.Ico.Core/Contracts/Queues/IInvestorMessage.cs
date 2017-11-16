namespace Lykke.Ico.Core.Contracts.Queues
{
    public interface IInvestorMessage : IMessage
    {
        string EmailTo { get; set; }
        int Attempts { get; set; }
    }
}
