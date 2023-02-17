namespace Budgethold.Shared.Tests.MessageBroker;

using Abstractions.Messenger;

public class TestMessageBroker : IMessageBroker
{
    private readonly List<IMessage> _messages = new();

    public IReadOnlyList<IMessage> Messages => _messages;

    public Task PublishAsync(IMessage message, CancellationToken cancellationToken = default)
    {
        _messages.Add(message);
        return Task.CompletedTask;
    }

    public Task PublishAsync(IEnumerable<IMessage> messages, CancellationToken cancellationToken = default)
    {
        _messages.AddRange(messages);
        return Task.CompletedTask;
    }
}