using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Ico.Core.Repositories.CryptoInvestment
{
    public interface ICryptoInvestment
    {
        string InvestorEmail { get; }
        string TransactionId { get; }
        string BlockId { get; set; }
        DateTimeOffset BlockTimestamp { get; set; }
        string DestinationAddress { get; set; }
        CurrencyType CurrencyType { get; set; }
        decimal Amount { get; set; }
        decimal ExchangeRate { get; set; }
        decimal AmountUsd { get; set; }
        decimal Price { get; set; }
        decimal AmountVld { get; set; }
    }
}
