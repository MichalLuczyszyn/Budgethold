namespace Budgethold.Modules.Wallets.Domain.Wallets.Events;

using Entities;
using Shared.Abstractions.Kernel;

internal record WalletPrivatized(Wallet Wallet) : IDomainEvent;