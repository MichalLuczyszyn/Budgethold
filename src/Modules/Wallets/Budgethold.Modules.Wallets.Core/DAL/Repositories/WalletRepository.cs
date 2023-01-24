namespace Budgethold.Modules.Wallets.Core.DAL.Repositories;

using Budgethold.Modules.Wallets.Core.Entities;
using Budgethold.Modules.Wallets.Core.Repositories;
using Microsoft.EntityFrameworkCore;

internal class WalletRepository : IWalletRepository
{
    private readonly WalletsDbContext _dbContext;
    private readonly DbSet<Wallet> _wallets;

    public WalletRepository(WalletsDbContext dbContext)
    {
        _dbContext = dbContext;
        _wallets = _dbContext.Wallets;
    }

    public async Task<Wallet> GetAsync(Guid id) => await _wallets.Include(x => x.Transactions).FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(Wallet wallet)
    {
        _wallets.Add(wallet);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Wallet wallet)
    {
        _wallets.Update(wallet);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Wallet wallet)
    {
        _wallets.Remove(wallet);
        await _dbContext.SaveChangesAsync();
    }
}
