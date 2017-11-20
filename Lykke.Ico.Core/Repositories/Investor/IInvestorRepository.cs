﻿using Lykke.Ico.Core.Contracts.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Repositories.Investor
{
    public interface IInvestorRepository
    {
        Task<IEnumerable<IInvestor>> GetAllAsync();

        Task<IInvestor> GetAsync(string email);

        Task<IInvestor> AddAsync(string email, string ipAddress);

        Task UpdateAddressesAsync(string email, string tokenAddress, string refundEthAddress, string refundBtcAddress);

        Task UpdatePayInAddressesAsync(string email, string payInEthPublicKey, string payInBtcPublicKey);

        Task RemoveAsync(string email);
    }
}
