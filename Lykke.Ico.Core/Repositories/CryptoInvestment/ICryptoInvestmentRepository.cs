using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.CryptoInvestment
{
    public interface ICryptoInvestmentRepository
    {
        Task<IEnumerable<ICryptoInvestment>> GetInvestmentsAsync(string investorEmail);

        Task SaveAsync(
            string investorEmail, 
            string txId, 
            string blockId, 
            DateTimeOffset blockTimestamp, 
            string destinationAddress, 
            CurrencyType currencyType,
            decimal amount,
            decimal exchangeRate,
            decimal amountUsd);
    }
}
