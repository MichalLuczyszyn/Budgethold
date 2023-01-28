namespace Budgethold.Shared.Abstractions.Events;

public interface IEventDispatcher
{
    Task PublishAsync<Tevent>(Tevent @event) where Tevent : class, IEvent;
}
