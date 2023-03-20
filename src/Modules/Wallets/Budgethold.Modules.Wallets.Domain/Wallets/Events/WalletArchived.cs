namespace Budgethold.Modules.Wallets.Domain.Wallets.Events;

using Entities;
using Shared.Abstractions.Events;
using Shared.Abstractions.Kernel;

internal record WalletArchived(Wallet Wallet) : IDomainEvent;
