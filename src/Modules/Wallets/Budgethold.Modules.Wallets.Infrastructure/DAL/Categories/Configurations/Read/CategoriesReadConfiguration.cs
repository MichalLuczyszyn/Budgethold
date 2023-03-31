namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Categories.Configurations.Read;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

internal class CategoriesReadConfiguration : IEntityTypeConfiguration<CategoryReadModel>
{
    public void Configure(EntityTypeBuilder<CategoryReadModel> builder)
    {
        builder.HasKey(q => q.Id);

        builder.HasQueryFilter(x => x.ArchivedAt.HasValue);
        
        builder.HasOne(x => x.Wallet)
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.WalletId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable(Constants.repeatableTransactions);
    }
}
