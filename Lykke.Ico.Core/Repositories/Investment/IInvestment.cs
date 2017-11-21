using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Ico.Core.Repositories.Investment
{
    public interface IInvestment
    {
        string Email { get; }
        string Transaction { get; }
        CurrencyType CurrencyType { get; set; }
        decimal Amount { get; set; }
        decimal AmountUsd { get; set; }
    }
}
