namespace Budgethold.Modules.Wallets.Core.Repositories;

using Budgethold.Modules.Wallets.Core.Entities;

public interface ITransactionRepository
{
    Task<Transaction> GetAsync(Guid id);

    Task AddAsync(Transaction transaction);

    Task UpdateAsync(Transaction transaction);

    Task DeleteAsync(Transaction transaction);
}
