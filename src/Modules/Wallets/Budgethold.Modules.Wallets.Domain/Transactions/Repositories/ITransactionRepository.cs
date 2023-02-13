namespace Budgethold.Modules.Wallets.Domain.Transactions.Repositories;

using Budgethold.Modules.Wallets.Domain.Transactions.Entities;

internal interface ITransactionRepository
{
    Task<Transaction?> GetAsync(Guid id);

    Task AddAsync(Transaction transaction);

    Task UpdateAsync(Transaction transaction);

    Task DeleteAsync(Transaction transaction);
}
