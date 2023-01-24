namespace Budgethold.Modules.Wallets.Core.DAL.Configurations;

using Budgethold.Modules.Wallets.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TransactionsConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Amount).HasPrecision(19, 4);

        builder.Property(x => x.Name).HasMaxLength(100);
    }
}