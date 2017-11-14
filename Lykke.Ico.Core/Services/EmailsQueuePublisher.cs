using AzureStorage.Queue;
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
            var queueName = GetQueueName();

            _queue = AzureQueueExt.Create(connectionStringManager, queueName);

            _queue.RegisterTypes(new QueueType[] { new QueueType() { Type = typeof(TMessage) } });
        }

        private string GetQueueName()
        {
            var t = typeof(TMessage);

            if (t == typeof(InvestorConfirmation))
            {
                return Consts.Queues.Email.InvestorConfirmation;
            }
            if (t == typeof(InvestorKycRequest))
            {
                return Consts.Queues.Email.InvestorKycRequest;
            }
            if (t == typeof(InvestorNewTransaction))
            {
                return Consts.Queues.Email.InvestorNewTransaction;
            }
            if (t == typeof(InvestorSummary))
            {
                return Consts.Queues.Email.InvestorNewTransaction;
            }
            if (t == typeof(AdminNewTransaction))
            {
                return Consts.Queues.Email.AdminNewTransaction;
            }

            throw new ArgumentException($"Unsupported type {t.FullName}");
        }

        public async Task SendAsync(TMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            await _queue.PutMessageAsync(message);
        }            
    }
}
