namespace Lykke.Ico.Core
{
    public class Consts
    {
        public class Emails
        {
            public class Queues
            {
                public const string InvestorConfirmation = "investor-email-confirmation";
                public const string InvestorSummary = "investor-email-summary";
                public const string InvestorNewTransaction = "investor-email-new-transaction";
                public const string InvestorKycReminder = "investor-kyc-reminder";
                public const string InvestorReferralCode = "investor-referral-code";
                public const string Investor20MFix = "investor-20m-fix";
            }
        }

        public class Transactions
        {
            public class Queues
            {
                public const string Investor = "investor-transaction";
            }
        }

        public class CrowdSale
        {
            public const decimal InitialAmount = 20_000_000M;
        }
    }
}
