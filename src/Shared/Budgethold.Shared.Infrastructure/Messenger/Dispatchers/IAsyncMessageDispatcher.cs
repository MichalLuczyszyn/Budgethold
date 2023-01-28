namespace Budgethold.Shared.Infrastructure.Messenger.Dispatchers;

using Abstractions.Messenger;

internal interface IAsyncMessageDispatcher
{
    Task PublishAsync<TMessage>(TMessage message) where TMessage : class, IMessage;
}