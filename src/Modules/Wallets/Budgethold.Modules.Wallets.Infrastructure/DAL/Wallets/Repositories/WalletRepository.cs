namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Wallets.Repositories;

using Budgethold.Modules.Wallets.Domain.Wallets.Entities;
using Budgethold.Modules.Wallets.Domain.Wallets.Repositories;
using Context;
using Microsoft.EntityFrameworkCore;

internal class WalletRepository : IWalletRepository
{
    private readonly WalletsWriteDbContext _dbContext;
    private readonly DbSet<Wallet> _wallets;

    public WalletRepository(WalletsWriteDbContext dbContext)
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
