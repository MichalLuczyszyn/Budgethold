namespace Budgethold.Modules.Wallets.Core.Services;

using Shared.Abstractions.Kernel;
using Shared.Abstractions.Messenger;

public interface IEventMapper
{
    IMessage Map(IDomainEvent domainEvent);
    IEnumerable<IMessage> Map(IEnumerable<IDomainEvent> domainEvents);
}
