using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.PrivateInvestor
{
    public interface IPrivateInvestorRepository
    {
        Task<IPrivateInvestor> AddAsync(string email);
        Task<IEnumerable<IPrivateInvestor>> GetAllAsync();
        Task<IPrivateInvestor> GetAsync(string email);
        Task SaveKycAsync(string email, string kycRequestId);
        Task SaveKycResultAsync(string email, bool? kycPassed, bool manual = false);
        Task RemoveAsync(string email);
    }
}
