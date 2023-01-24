namespace Budgethold.Modules.Wallets.Core.Repositories;

using Budgethold.Modules.Wallets.Core.Entities;

public interface IWalletRepository
{
    Task<Wallet> GetAsync(Guid id);

    Task AddAsync(Wallet wallet);

    Task UpdateAsync(Wallet wallet);

    Task DeleteAsync(Wallet wallet);
}
