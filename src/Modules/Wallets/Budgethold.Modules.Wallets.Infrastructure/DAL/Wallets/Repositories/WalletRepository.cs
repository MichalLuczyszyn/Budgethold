namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Wallets.Repositories;

using Budgethold.Modules.Wallets.Domain.Wallets.Entities;
using Budgethold.Modules.Wallets.Domain.Wallets.Repositories;
using Context;
using Microsoft.EntityFrameworkCore;
using Shared.Abstractions.Kernel.Types;

internal class WalletRepository : IWalletRepository
{
    private readonly WalletsWriteDbContext _dbContext;
    private readonly WalletsReadDbContext _walletsReadDbContext;
    private readonly DbSet<Wallet> _wallets;

    public WalletRepository(WalletsWriteDbContext dbContext, WalletsReadDbContext walletsReadDbContext)
    {
        _dbContext = dbContext;
        _walletsReadDbContext = walletsReadDbContext;
        _wallets = _dbContext.Wallets;
    }

    public async Task<bool> ExistAsync(string name, CancellationToken cancellationToken) =>
        await _walletsReadDbContext.Wallets.AnyAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken: cancellationToken);

    public async Task<Wallet?> GetAsync(Guid id, CancellationToken cancellationToken) => await _wallets
        .Include(x => x.Transactions)
        .Include(x => x.RepeatableTransactions)
        .Where(x => x.Id == id)
        .FirstOrDefaultAsync(cancellationToken);

    public async Task AddAsync(Wallet wallet, CancellationToken cancellationToken)
    {
        _wallets.Add(wallet);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken) => await _dbContext.SaveChangesAsync(cancellationToken);

    public async Task SaveChangeAsync(Wallet wallet, CancellationToken cancellationToken)
    {
        _wallets.Update(wallet);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
