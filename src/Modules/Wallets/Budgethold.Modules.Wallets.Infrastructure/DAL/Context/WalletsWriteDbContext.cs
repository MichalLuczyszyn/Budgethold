namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Context;

using Budgethold.Modules.Wallets.Domain.Transactions.Entities;
using Budgethold.Modules.Wallets.Domain.Wallets.Entities;
using Microsoft.EntityFrameworkCore;

public class WalletsWriteDbContext : DbContext
{
    public WalletsWriteDbContext(DbContextOptions<WalletsWriteDbContext> options)
        : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; }

    public DbSet<Wallet> Wallets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("wallets");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}