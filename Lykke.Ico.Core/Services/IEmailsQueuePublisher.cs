using Lykke.Ico.Core.Contracts.Emails;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Services
{
    public interface IEmailsQueuePublisher<TMessage>
        where TMessage : IEmailMessage
    {
        Task SendAsync(TMessage message);
    }
}
