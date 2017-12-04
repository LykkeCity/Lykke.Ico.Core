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

        Task ConfirmAsync(string email);

        Task SaveAddressesAsync(string email, string tokenAddress, string refundEthAddress, string refundBtcAddress,
           string payInEthPublicKey, string payInEthAddress, string payInBtcPublicKey, string payInBtcAddress);

        Task IncrementBtc(string email, decimal amountBtc, decimal amountUsd, decimal amountVld);

        Task IncrementEth(string email, decimal amountEth, decimal amountUsd, decimal amountVld);

        Task IncrementFiat(string email, decimal amountFiat, decimal amountUsd, decimal amountVld);

        Task RemoveAsync(string email);
    }
}
