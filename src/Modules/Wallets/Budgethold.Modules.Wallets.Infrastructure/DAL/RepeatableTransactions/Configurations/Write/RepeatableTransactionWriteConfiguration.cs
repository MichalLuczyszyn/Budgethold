﻿namespace Budgethold.Modules.Wallets.Infrastructure.DAL.RepeatableTransactions.Configurations.Write;

using Domain.RepeatableTransactions.Entities;
using Domain.RepeatableTransactions.Types;
using Domain.Transactions.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Abstractions.Kernel.ValueObjects.Texts;
using Shared.Abstractions.Kernel.ValueObjects.Transactions;

internal class RepeatableTransactionWriteConfiguration : IEntityTypeConfiguration<RepeatableTransaction>
{
    public void Configure(EntityTypeBuilder<RepeatableTransaction> builder)
    {
        builder.Property(x => x.Id)
            .IsRequired()
            .HasConversion(x => x.Value, x => new RepeatableTransactionId(x));

        builder.Property<ShortText>("Name")
            .HasConversion(x => x.Value, x => new ShortText(x))
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property<LongText>("Description")
            .HasConversion(x => x.Value, x => new LongText(x))
            .HasMaxLength(500);
        
        builder.OwnsOne<Amount>("Amount",
            amount =>
            {
                amount.Property<decimal>("Value")
                    .HasPrecision(19,4).HasColumnName("Amount");

                amount.Property<string>("Currency").HasMaxLength(50).IsRequired().HasColumnName("Currency");
            });

        builder.HasOne(x => x.Wallet)
            .WithMany(x => x.RepeatableTransactions)
            .HasForeignKey(x => x.WalletId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable(Constants.repeatableTransactions);
    }
}