namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Transactions.Configurations.Read;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

internal class TransactionsReadConfiguration : IEntityTypeConfiguration<TransactionReadModel>
{
    public void Configure(EntityTypeBuilder<TransactionReadModel> builder)
    {
        builder.HasKey(q => q.Id);
        
        builder.HasQueryFilter(x => x.ArchivedAt.HasValue);
        
        builder.HasOne(x => x.Wallet)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.WalletId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(x => x.RepeatableTransaction)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.RepeatableTransactionId)
            .OnDelete(DeleteBehavior.NoAction);        
        
        builder.HasOne(x => x.Category)
            .WithMany(x => x.Transactions)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.ToTable(Constants.transactions);
    }
}
