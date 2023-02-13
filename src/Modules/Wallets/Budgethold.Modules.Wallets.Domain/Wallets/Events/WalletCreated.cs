namespace Budgethold.Modules.Wallets.Domain.Wallets.Events;

using Entities;
using Shared.Abstractions.Kernel;

internal record WalletCreated(Wallet Wallet) : IDomainEvent;
