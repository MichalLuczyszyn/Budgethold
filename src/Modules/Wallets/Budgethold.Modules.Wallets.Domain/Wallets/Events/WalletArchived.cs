namespace Budgethold.Modules.Wallets.Domain.Wallets.Events;

using Shared.Abstractions.Events;

internal record WalletArchived(Guid WalletId) : IEvent;
