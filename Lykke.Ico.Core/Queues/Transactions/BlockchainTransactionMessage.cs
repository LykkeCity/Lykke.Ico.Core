using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Ico.Core.Queues.Transactions
{
    [QueueMessage(QueueName = Consts.Transactions.Queues.BlockchainTransaction)]
    public class BlockchainTransactionMessage : IMessage
    {
        public string TransactionId { get; set; }
        public string DestinationAddress { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public decimal Amount { get; set; }
    }
}
