namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Wallets.Configurations.Write;

using Budgethold.Modules.Wallets.Domain.Wallets.Entities;
using Domain.Wallets.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Abstractions.Kernel.Types;

internal class WalletsWriteConfiguration : IEntityTypeConfiguration<Wallet>
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.Property<WalletId>("Id")
            .IsRequired()
            .HasConversion(x => x.Value, x => new WalletId(x));
        
        builder.Property<WalletType>("WalletType")
            .HasConversion(x => x.Value, x => new WalletType(x))
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property<WalletName>("Name")
            .HasConversion(x => x.Value, x => new WalletName(x))
            .IsRequired()
            .HasMaxLength(100);

        builder.ToTable(Constants.wallets);
    }
}
