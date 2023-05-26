namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Categories.Configurations.Write;

using Domain.Categories.Entities;
using Domain.Categories.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Abstractions.Kernel.ValueObjects.Texts;

internal class CategoriesWriteConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property<DateTimeOffset?>("ArchivedAt");
        builder.Property<DateTimeOffset>("CreatedAt");
        
        builder.HasQueryFilter(x => !EF.Property<DateTimeOffset?>(x, "ArchivedAt").HasValue);
        
        builder.Property<CategoryId>("Id")
            .IsRequired()
            .HasConversion(x => x.Value, x => new CategoryId(x));
        
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
