namespace Lykke.Ico.Core.Contracts
{
    public class EmailMessage
    {
        public EmailType Type { get; set; }
        public string EmailTo { get; set; }
        public string Parameters { get; set; }
    }
}
