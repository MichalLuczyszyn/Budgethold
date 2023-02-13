namespace Budgethold.Modules.Wallets.Domain.Wallets.Events;

using Shared.Abstractions.Kernel;
using Shared.Abstractions.Kernel.Types;

internal record WalletArchived(WalletId WalletId) : IDomainEvent;
