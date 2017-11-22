using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Ico.Core.Repositories.Investment
{
    public interface ICryptoInvestment
    {
        string InvestorEmail { get; }
        string TransactionId { get; }
        string BlockId { get; set; }
        DateTimeOffset BlockTimestamp { get; set; }
        string DestinationAddress { get; set; }
        CurrencyType CurrencyType { get; set; }
        decimal ExchangeRate { get; set; }
        decimal Amount { get; set; }
        decimal AmountUsd { get; set; }
    }
}
