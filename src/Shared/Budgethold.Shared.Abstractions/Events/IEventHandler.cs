namespace Budgethold.Shared.Abstractions.Events;

public interface IEventHandler<in Tevent> where Tevent : class, IEvent
{
    Task HandleAsync(Tevent @event);
}
