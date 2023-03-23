namespace Budgethold.Shared.Abstractions.Kernel;

public interface IDomainEventHandler<in TEvent> where TEvent : class, IDomainEvent
{
    public Task HandleAsync(TEvent @event);
}
