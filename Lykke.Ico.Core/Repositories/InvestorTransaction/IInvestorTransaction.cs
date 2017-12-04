using System;

namespace Lykke.Ico.Core.Repositories.CryptoInvestment
{
    public interface IInvestorTransaction
    {
        string Email { get; }
        string InternalId { get; }
        DateTime CreatedUtc { get; set; }
        CurrencyType Currency { get; set; }
        string BlockId { get; set; }
        string Transaction { get; set; }
        string PayInAddress { get; set; }
        decimal Amount { get; set; }
        decimal AmountUsd { get; set; }
        decimal AmountToken { get; set; }
        decimal TokenPrice { get; set; }
        decimal ExchangeRate { get; set; }
        string ExchangeRateContext { get; set; }
    }
}
