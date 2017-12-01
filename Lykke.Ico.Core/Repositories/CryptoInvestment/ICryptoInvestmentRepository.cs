using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.CryptoInvestment
{
    public interface ICryptoInvestmentRepository
    {
        Task<IEnumerable<ICryptoInvestment>> GetInvestmentsAsync(string investorEmail);

        Task SaveAsync(ICryptoInvestment entity);

        Task SaveEmailTimestampAsync(string investorEmail, string txId, DateTime? timestamp = null);
    }
}
