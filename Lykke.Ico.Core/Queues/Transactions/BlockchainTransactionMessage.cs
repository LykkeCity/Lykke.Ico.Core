using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Ico.Core.Queues.Transactions
{
    [QueueMessage(QueueName = Consts.Transactions.Queues.BlockchainTransaction)]
    public class BlockchainTransactionMessage : IMessage
    {
        public string Link { get; set; }

        /// <summary>
        /// Block hash
        /// </summary>
        public string BlockId { get; set; }

        public DateTimeOffset BlockTimestamp { get; set; }

        /// <summary>
        /// Outpoint for BTC | hash for ETH
        /// </summary>
        public string TransactionId { get; set; }
        
        public string DestinationAddress { get; set; }

        /// <summary>
        /// Bitcoin | Ether
        /// </summary>
        public CurrencyType CurrencyType { get; set; }

        public decimal Amount { get; set; }
    }
}
