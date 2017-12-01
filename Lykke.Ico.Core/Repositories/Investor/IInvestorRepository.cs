using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.Investor
{
    public interface IInvestorRepository
    {
        Task<IEnumerable<IInvestor>> GetAllAsync();

        Task<IInvestor> GetAsync(string email);

        Task<IInvestor> AddAsync(string email, Guid confirmationToken);

        Task UpdateAsync(IInvestor investor);

        Task RemoveAsync(string email);

        Task UpdateAsync(string email, string kycProcessId = null, string kycResult = null, bool? kycSucceeded = null,
            decimal? amountBtc = null,
            decimal? amountEth = null,
            decimal? amountUsd = null,
            decimal? amountVld = null);
    }
}
