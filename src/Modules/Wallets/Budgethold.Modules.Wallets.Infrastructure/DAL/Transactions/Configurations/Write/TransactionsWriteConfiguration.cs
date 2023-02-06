namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Transactions.Configurations.Write;

using Budgethold.Modules.Wallets.Domain.Transactions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TransactionsWriteConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Amount).HasPrecision(19, 4);

        builder.Property(x => x.Name).HasMaxLength(100);
        
        builder.ToTable(Constants.Transactions);
    }
}