namespace Budgethold.Shared.Infrastructure.Messenger;

using Abstractions.Messenger;
using Brokers;
using Dispatchers;
using Microsoft.Extensions.DependencyInjection;

internal static class Extensions
{
    private const string SectionName = "messenger";

    internal static IServiceCollection AddMessenger(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IMessageBroker, InMemoryMessageBroker>();
        serviceCollection.AddSingleton<IMessageChannel, MessageChannel>();
        serviceCollection.AddSingleton<IAsyncMessageDispatcher, AsyncMessageDispatcher>();

        var messengerOptions = serviceCollection.GetOptions<MessengerOptions>(SectionName);
        serviceCollection.AddSingleton(messengerOptions);

        if (messengerOptions.UseBackgroundDispatcher)
            serviceCollection.AddHostedService<BackgroundDispatcher>();

        return serviceCollection;
    }
}
