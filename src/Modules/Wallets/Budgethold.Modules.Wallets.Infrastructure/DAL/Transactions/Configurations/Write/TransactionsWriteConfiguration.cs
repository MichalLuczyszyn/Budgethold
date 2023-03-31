namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Transactions.Configurations.Write;

using Budgethold.Modules.Wallets.Domain.Transactions.Entities;
using Domain.Transactions.Types;
using Domain.Transactions.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Abstractions.Kernel.ValueObjects.Texts;
using Shared.Abstractions.Kernel.ValueObjects.Transactions;

internal class TransactionsWriteConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.Property(x => x.Id)
            .IsRequired()
            .HasConversion(x => x.Value, x => new TransactionId(x));

        builder.Property<ShortText>("Name")
            .HasConversion(x => x.Value,
                x => new ShortText(x))
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property<LongText>("Description")
            .HasConversion(x => x.Value,
                x => new LongText(x))
            .HasMaxLength(500);
        
        builder.OwnsOne<Amount>("Amount",
            amount =>
            {
                amount.Property<decimal>("Value")
                    .HasPrecision(19,4).HasColumnName("Amount");

                amount.Property<string>("Currency").HasMaxLength(50).IsRequired().HasColumnName("Currency");
            });
        
        builder.Property<TransactionType>("TransactionType")
            .HasConversion(x => x.Value,
                x => new TransactionType(x))
            .HasMaxLength(100);

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