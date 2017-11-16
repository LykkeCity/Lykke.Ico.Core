using Lykke.Ico.Core.Contracts.Queues;
using System.Threading.Tasks;

namespace Lykke.Ico.Core.Services
{
    public interface IQueuePublisher<TMessage>
        where TMessage : IMessage
    {
        Task SendAsync(TMessage message);
    }
}
