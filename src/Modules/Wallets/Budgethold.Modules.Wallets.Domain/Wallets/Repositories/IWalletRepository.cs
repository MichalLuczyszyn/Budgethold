namespace Budgethold.Modules.Wallets.Domain.Wallets.Repositories;

using Budgethold.Modules.Wallets.Domain.Wallets.Entities;
using Shared.Abstractions.Kernel.Types;

internal interface IWalletRepository
{
    Task<bool> ExistAsync(string name, CancellationToken cancellationToken);
    Task<Wallet?> GetAsync(Guid id, CancellationToken cancellationToken);

    Task AddAsync(Wallet wallet, CancellationToken cancellationToken);

    Task CommitAsync(CancellationToken cancellationToken);
    Task SaveChangeAsync(Wallet wallet, CancellationToken cancellationToken);

}
