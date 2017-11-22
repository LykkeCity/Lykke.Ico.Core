namespace Lykke.Ico.Core.Repositories.EmailHistory
{
    public interface IEmailHistoryItem
    {
        string Email { get; }

        string When { get; }

        string Subject { get; set; }

        string Body { get; set; }
    }
}
