namespace Budgethold.Modules.Wallets.Core.DAL.Repositories;

using Budgethold.Modules.Wallets.Core.Entities;
using Budgethold.Modules.Wallets.Core.Repositories;
using Microsoft.EntityFrameworkCore;

internal class TransactionRepository : ITransactionRepository
{
    private readonly WalletsDbContext _dbContext;
    private readonly DbSet<Transaction> _transactions;

    public TransactionRepository(WalletsDbContext dbContext)
    {
        _dbContext = dbContext;
        _transactions = _dbContext.Transactions;
    }

    public async Task<Transaction> GetAsync(Guid id) => await _transactions.FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(Transaction transaction)
    {
        _transactions.Add(transaction);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Transaction transaction)
    {
        _transactions.Update(transaction);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Transaction transaction)
    {
        _transactions.Remove(transaction);
        await _dbContext.SaveChangesAsync();
    }
}
