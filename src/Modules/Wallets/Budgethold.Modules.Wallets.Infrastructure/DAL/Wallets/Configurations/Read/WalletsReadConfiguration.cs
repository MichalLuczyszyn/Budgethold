namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Wallets.Configurations.Read;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

internal class WalletsReadConfiguration : IEntityTypeConfiguration<WalletReadModel>
{
    public void Configure(EntityTypeBuilder<WalletReadModel> builder)
    {
        builder.HasKey(q => q.Id);
        builder.HasQueryFilter(x => x.ArchivedAt.HasValue);
        
        builder.ToTable(Constants.wallets);
    }
}
