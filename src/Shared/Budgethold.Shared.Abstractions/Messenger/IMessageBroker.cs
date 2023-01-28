namespace Budgethold.Shared.Abstractions.Messenger;

public interface IMessageBroker
{
    Task PublishAsync(params IMessage[] messages);
}
