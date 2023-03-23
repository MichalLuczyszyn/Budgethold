namespace Budgethold.Shared.Abstractions.Kernel;

public interface IDomainEventDispatcher
{
    public Task DispatchAsync(params IDomainEvent[] events);
}
