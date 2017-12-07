using System;

namespace Lykke.Ico.Core.Queues.Transactions
{
    [QueueMessage(QueueName = Consts.Transactions.Queues.Investor)]
    public class TransactionMessage : IMessage
    {
        public string Email { get; set; }

        public string TransactionId { get; set; }

        public DateTime CreatedUtc { get; set; }

        public CurrencyType Currency { get; set; }

        public decimal Amount { get; set; }

        /// <summary>
        /// Fiat only: must be 0 for crypto cases
        /// </summary>
        public decimal Fee { get; set; }

        /// <summary>
        /// Crypto only: URL to blockchain explorer for transaction
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Crypto only: Block hash
        /// </summary>
        public string BlockId { get; set; }

        /// <summary>
        /// Crypto only: Pay-in address
        /// </summary>
        public string PayInAddress { get; set; }
    }
}
