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
            }

            public class Subjects
            {
                public const string InvestorConfirmation = "Email Confirmation - Procivis ICO";
                public const string InvestorSummary = "Summary - Procivis ICO";
                public const string InvestorNewTransaction = "New Transaction - Procivis ICO";
            }

            public class BodyTemplates
            {
                public const string InvestorConfirmation = "investor-confirmation";
                public const string InvestorSummary = "investor-summary";
                public const string InvestorNewTransaction = "investor-new-transaction";
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
