namespace Budgethold.Modules.Categories.Application.Events.Wallets.External;

using Shared.Abstractions.Events;

internal record WalletArchived(Guid WalletId) : IEvent;
