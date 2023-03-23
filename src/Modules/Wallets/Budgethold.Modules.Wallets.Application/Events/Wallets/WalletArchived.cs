namespace Budgethold.Modules.Wallets.Core.Events.Wallets;

using Shared.Abstractions.Events;

public record WalletArchived(Guid Id) : IEvent;
