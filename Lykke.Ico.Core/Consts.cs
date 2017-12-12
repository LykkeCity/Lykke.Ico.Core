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
                public const string InvestorKycRequest = "investor-email-kyc-request";
                public const string InvestorNewTransaction = "investor-email-new-transaction";
                public const string InvestorNeedMoreInvestment = "investor-email-need-more-investment";
            }

            public class Subjects
            {
                public const string InvestorConfirmation = "Email Confirmation - Procivis ICO";
                public const string InvestorSummary = "Summary - Procivis ICO";
                public const string InvestorKycRequest = "KYC Required - Procivis ICO";
                public const string InvestorNewTransaction = "New Transaction - Procivis ICO";
                public const string InvestorNeedMoreInvestment = "Need More Investment - Procivis ICO";
            }

            public class BodyTemplates
            {
                public const string InvestorConfirmation = "investor-confirmation";
                public const string InvestorSummary = "investor-summary";
                public const string InvestorKycRequest = "investor-kyc-request";
                public const string InvestorNewTransaction = "investor-new-transaction";
                public const string InvestorNeedMoreInvestment = "investor-need-more-investment";
            }
        }

        public class Transactions
        {
            public class Queues
            {
                public const string Investor = "investor-transaction";
            }
        }
    }
}
