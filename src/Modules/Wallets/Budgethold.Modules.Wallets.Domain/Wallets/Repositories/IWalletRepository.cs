namespace Budgethold.Modules.Wallets.Domain.Wallets.Repositories;

using Budgethold.Modules.Wallets.Domain.Wallets.Entities;

public interface IWalletRepository
{
    Task<Wallet> GetAsync(Guid id);

    Task AddAsync(Wallet wallet);

    Task UpdateAsync(Wallet wallet);

    Task DeleteAsync(Wallet wallet);
}
