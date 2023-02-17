namespace Budgethold.Shared.Infrastructure.Messenger.Brokers;

using Abstractions.Messenger;
using Abstractions.Modules;
using Dispatchers;

internal class InMemoryMessageBroker : IMessageBroker
{
    private readonly IModuleClient _moduleClient;
    private readonly IAsyncMessageDispatcher _asyncMessageDispatcher;
    private readonly MessengerOptions _messengerOptions;

    public InMemoryMessageBroker(IModuleClient moduleClient, IAsyncMessageDispatcher asyncMessageDispatcher, MessengerOptions messengerOptions)
    {
        _moduleClient = moduleClient;
        _asyncMessageDispatcher = asyncMessageDispatcher;
        _messengerOptions = messengerOptions;
    }

    public async Task PublishAsync(IEnumerable<IMessage> messages, CancellationToken cancellationToken)
    {
        if (messages is null) return;

        messages = messages.Where(x => x is not null).ToArray();

        if (!messages.Any()) return;

        var tasks = new List<Task>();
        foreach (var message in messages)
        {
            if (_messengerOptions.UseBackgroundDispatcher)
            {
                await _asyncMessageDispatcher.PublishAsync(message, cancellationToken);
                continue;
            }
            
            tasks.Add(_moduleClient.PublishAsync(message));
        }
        
        await Task.WhenAll(tasks);
    }
}
