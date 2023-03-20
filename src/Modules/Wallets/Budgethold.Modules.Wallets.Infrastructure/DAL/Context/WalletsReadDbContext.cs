namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Context;

using Microsoft.EntityFrameworkCore;
using RepeatableTransactions.Configurations.Read;
using RepeatableTransactions.Configurations.Read.Model;
using Transactions.Configurations.Read;
using Transactions.Configurations.Read.Model;
using Wallets.Configurations.Read;
using Wallets.Configurations.Read.Model;

internal class WalletsReadDbContext : DbContext
{
    public DbSet<WalletReadModel> Wallets { get; set; }
    public DbSet<TransactionReadModel> Transactions { get; set; }
    public DbSet<RepeatableTransactionReadModel> RepeatableTransactions { get; set; }
    public WalletsReadDbContext(DbContextOptions<WalletsReadDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(Constants.wallets);
        
        modelBuilder.ApplyConfiguration(new WalletsReadConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionsReadConfiguration());
        modelBuilder.ApplyConfiguration(new RepeatableTransactionReadConfiguration());
    }
}