namespace Budgethold.Modules.Categories.Application.Events.Wallets.External.Handlers;

using Shared.Abstractions.Events;

internal class WalletArchivedHandler : IEventHandler<WalletArchived>
{
    public WalletArchivedHandler()
    {
        
    }
    public async Task HandleAsync(WalletArchived @event) => throw new NotImplementedException();
}
