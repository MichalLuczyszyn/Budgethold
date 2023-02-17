namespace Budgethold.Shared.Infrastructure.Messenger.Dispatchers;

using Abstractions.Messenger;

internal interface IAsyncMessageDispatcher
{
    Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken) where TMessage : class, IMessage;
}