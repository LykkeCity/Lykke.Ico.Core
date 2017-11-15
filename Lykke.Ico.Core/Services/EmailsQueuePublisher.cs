using AzureStorage.Queue;
using Common;
using Lykke.Ico.Core.Contracts.Emails;
using Lykke.SettingsReader;
using System;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Services
{
    public class EmailsQueuePublisher<TMessage> : IEmailsQueuePublisher<TMessage>
        where TMessage : IEmailMessage
    {
        private readonly IQueueExt _queue;

        public EmailsQueuePublisher(IReloadingManager<string> connectionStringManager)
        {
            var t = typeof(TMessage);
            var queueName = GetQueueName(t);

            _queue = AzureQueueExt.Create(connectionStringManager, queueName);
        }

        private string GetQueueName(Type t)
        {
            if (t == typeof(InvestorConfirmation))
            {
                return Consts.Emails.Queues.InvestorConfirmation;
            }
            if (t == typeof(InvestorKycRequest))
            {
                return Consts.Emails.Queues.InvestorKycRequest;
            }
            if (t == typeof(InvestorNewTransaction))
            {
                return Consts.Emails.Queues.InvestorNewTransaction;
            }
            if (t == typeof(InvestorSummary))
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
