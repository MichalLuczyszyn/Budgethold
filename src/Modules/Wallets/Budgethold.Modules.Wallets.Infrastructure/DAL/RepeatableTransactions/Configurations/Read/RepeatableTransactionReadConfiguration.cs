namespace Budgethold.Modules.Wallets.Infrastructure.DAL.RepeatableTransactions.Configurations.Read;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

internal class RepeatableTransactionReadConfiguration : IEntityTypeConfiguration<RepeatableTransactionReadModel>
{
    public void Configure(EntityTypeBuilder<RepeatableTransactionReadModel> builder)
    {
        builder.HasKey(q => q.Id);
        
        builder.HasOne(x => x.Wallet)
            .WithMany(x => x.RepeatableTransactions)
            .HasForeignKey(x => x.WalletId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable(Constants.repeatableTransactions);
    }
}
