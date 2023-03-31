namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Categories.Configurations.Write;

using Domain.Categories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Abstractions.Kernel.ValueObjects.Texts;

internal class CategoriesWriteConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property<ShortText>("Name")
            .HasConversion(x => x.Value,
                x => new ShortText(x))
            .IsRequired()
            .HasMaxLength(100);
        
        builder.HasOne(x => x.Wallet)
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.WalletId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
