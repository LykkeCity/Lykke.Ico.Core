using System;

namespace Lykke.Ico.Core.Repositories.InvestorRefund
{
    public interface IInvestorRefund
    {
        string Email { get; }
        DateTime CreatedUtc { get; }
        InvestorRefundReason Reason { get; set; }
        string MessageJson { get; set; }
    }
}
