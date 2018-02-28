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

        Task SaveAddressesAsync(string email, string tokenAddress, string refundEthAddress, string refundBtcAddress);

        Task SaveAddressesAsync(string email, string tokenAddress, string refundEthAddress, string refundBtcAddress,
           string payInEthPublicKey, string payInEthAddress, string payInBtcPublicKey, string payInBtcAddress);

        Task IncrementAmount(string email, CurrencyType type, decimal amount, decimal amountUsd, decimal amountToken);

        Task IncrementTokens(string email, decimal amountToken);

        Task SaveKycAsync(string email, string kycRequestId);

        Task SaveKycResultAsync(string email, bool? kycPassed, bool manual = false);

        Task RemoveAsync(string email);

        Task SaveReferralCode(string email, string referralCode);

        Task ApplyReferralCode(string email, string referralCodeApplied);

        Task IncrementReferrals(string email);
    }
}
