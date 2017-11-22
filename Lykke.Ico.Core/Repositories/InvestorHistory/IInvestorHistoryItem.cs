namespace Lykke.Ico.Core.Repositories.InvestorHistory
{
    public interface IInvestorHistoryItem
    {
        string Email { get; }

        string When { get; }

        InvestorHistoryAction Action { get; set; }

        string Json { get; set; }
    }
}
