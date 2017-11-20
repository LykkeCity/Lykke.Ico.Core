using System.Threading.Tasks;

namespace Lykke.Ico.Core.Queues
{
    public interface IQueuePublisher<TMessage>
        where TMessage : IMessage
    {
        Task SendAsync(TMessage message);
    }
}
