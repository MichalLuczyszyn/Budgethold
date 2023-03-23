namespace Budgethold.Modules.Wallets.Core.Services;

using Domain.Wallets.Events;
using Events.Wallets;
using Shared.Abstractions.Kernel;
using Shared.Abstractions.Messenger;

public class EventMapper : IEventMapper
{
    public IMessage Map(IDomainEvent domainEvent)
        =>
            domainEvent switch
            {
                ArchiveWallet x => new WalletArchived(x.Wallet.Id)
            };
    

    public IEnumerable<IMessage> Map(IEnumerable<IDomainEvent> domainEvents) => domainEvents.Select(Map);
}
