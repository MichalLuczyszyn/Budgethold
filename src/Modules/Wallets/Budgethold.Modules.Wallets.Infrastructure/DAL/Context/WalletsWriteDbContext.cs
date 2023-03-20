namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Context;

using Budgethold.Modules.Wallets.Domain.Transactions.Entities;
using Budgethold.Modules.Wallets.Domain.Wallets.Entities;
using Domain.RepeatableTransactions.Entities;
using Microsoft.EntityFrameworkCore;
using RepeatableTransactions.Configurations.Write;
using Transactions.Configurations.Write;
using Wallets.Configurations.Write;

internal class WalletsWriteDbContext : DbContext
{
    public WalletsWriteDbContext(DbContextOptions<WalletsWriteDbContext> options)
        : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<RepeatableTransaction> RepeatableTransactions { get; set; }
    public DbSet<Wallet> Wallets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(Constants.wallets);

        modelBuilder.ApplyConfiguration(new WalletsWriteConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionsWriteConfiguration());
        modelBuilder.ApplyConfiguration(new RepeatableTransactionWriteConfiguration());
    }
}