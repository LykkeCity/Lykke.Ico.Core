using AzureStorage.Queue;
using Common;
using Lykke.Ico.Core.Queues.Emails;
using Lykke.SettingsReader;
using System;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Queues
{
    public class QueuePublisher<TMessage> : IQueuePublisher<TMessage>
        where TMessage : IMessage
    {
        private readonly IQueueExt _queue;

        public QueuePublisher(IReloadingManager<string> connectionStringManager)
        {
            var t = typeof(TMessage);
            var queueName = GetQueueName(t);

            _queue = AzureQueueExt.Create(connectionStringManager, queueName);
        }

        private string GetQueueName(Type t)
        {
            if (t == typeof(InvestorConfirmationMessage))
            {
                return Consts.Emails.Queues.InvestorConfirmation;
            }
            if (t == typeof(InvestorKycRequestMessage))
            {
                return Consts.Emails.Queues.InvestorKycRequest;
            }
            if (t == typeof(InvestorNewTransactionMessage))
            {
                return Consts.Emails.Queues.InvestorNewTransaction;
            }
            if (t == typeof(InvestorSummaryMessage))
            {
                return Consts.Emails.Queues.InvestorNewTransaction;
            }

            throw new ArgumentException($"Unsupported type {t.FullName}");
        }

        public async Task SendAsync(TMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            await _queue.PutRawMessageAsync(message.ToJson());
        }            
    }
}
