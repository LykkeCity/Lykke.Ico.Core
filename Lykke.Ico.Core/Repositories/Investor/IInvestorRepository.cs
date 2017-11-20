using Lykke.Ico.Core.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.Investor
{
    public interface IInvestorRepository
    {
        Task<IEnumerable<IInvestor>> GetAllAsync();

        Task<IInvestor> GetAsync(string email);

        Task<IInvestor> AddAsync(string email);

        Task UpdateAddressesAsync(string email, string tokenAddress, string refundEthAddress, string refundBtcAddress);

        Task UpdatePayInAddressesAsync(string email, string payInEthPublicKey, string payInBtcPublicKey);

        Task UpdateConfirmationTokenAsync(string email, Guid confirmationToken);

        Task RemoveAsync(string email);
    }
}
