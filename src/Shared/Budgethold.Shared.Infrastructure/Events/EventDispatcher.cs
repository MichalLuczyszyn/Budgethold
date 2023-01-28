namespace Budgethold.Shared.Infrastructure.Events;

using Abstractions.Events;
using Microsoft.Extensions.DependencyInjection;

internal sealed class EventDispatcher : IEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public EventDispatcher(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public async Task PublishAsync<Tevent>(Tevent @event) where Tevent : class, IEvent
    {
        using var scope = _serviceProvider.CreateScope();

        var handlers = scope.ServiceProvider.GetServices<IEventHandler<Tevent>>();

        var tasks = handlers.Select(x => x.HandleAsync(@event));

        await Task.WhenAll(tasks);
    }
}
