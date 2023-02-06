namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Wallets.Configurations.Write;

using Budgethold.Modules.Wallets.Domain.Wallets.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class WalletsWriteConfiguration : IEntityTypeConfiguration<Wallet>
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        
        builder.ToTable(Constants.Wallets);
    }
}
