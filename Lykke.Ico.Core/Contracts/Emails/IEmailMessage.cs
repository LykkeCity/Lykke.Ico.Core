namespace Lykke.Ico.Core.Contracts.Emails
{
    public interface IEmailMessage
    {
        string EmailTo { get; set; }
        int Attempts { get; set; }
    }
}
