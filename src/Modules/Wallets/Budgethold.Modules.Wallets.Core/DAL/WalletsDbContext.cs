namespace Budgethold.Modules.Wallets.Core.DAL;

using Entities;
using Microsoft.EntityFrameworkCore;

internal class WalletsDbContext : DbContext
{
    public WalletsDbContext(DbContextOptions<WalletsDbContext> options)
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