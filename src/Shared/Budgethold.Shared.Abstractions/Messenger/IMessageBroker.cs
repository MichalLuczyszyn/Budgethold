namespace Budgethold.Shared.Abstractions.Messenger;

public interface IMessageBroker
{
    Task PublishAsync(IEnumerable<IMessage> messages, CancellationToken cancellationToken);
}
