namespace Lykke.Ico.Core
{
    public class Consts
    {
        public class Emails
        {
            public class Queues
            {
                public const string InvestorConfirmation = "email-investor-confirmation";
                public const string InvestorSummary = "email-investor-summary";
                public const string InvestorKycRequest = "email-investor-kyc-request";
                public const string InvestorNewTransaction = "email-investor-new-transaction";
                public const string InvestorNeedMoreInvestment = "email-investor-need-more-investment";
            }

            public class Subjects
            {
                public const string InvestorConfirmation = "Email Confirmation - Procivis ICO";
                public const string InvestorSummary = "Summary - Procivis ICO";
                public const string InvestorKycRequest = "KYC Requered - Procivis ICO";
                public const string InvestorNewTransaction = "New Transaction - Procivis ICO";
                public const string InvestorNeedMoreInvestment = "Need More Investment - Procivis ICO";
            }

            public class BodyTemplates
            {
                public const string InvestorConfirmation = "investor-confirmation.html";
                public const string InvestorSummary = "investor-summary.html";
                public const string InvestorKycRequest = "investor-kyc-request.html";
                public const string InvestorNewTransaction = "investor-new-transaction.html";
                public const string InvestorNeedMoreInvestment = "investor-need-more-investment.html";
            }
        }

        public class Transactions
        {
            public class Queues
            {
                public const string Transactions = "transactions";
            }
        }
    }
}
