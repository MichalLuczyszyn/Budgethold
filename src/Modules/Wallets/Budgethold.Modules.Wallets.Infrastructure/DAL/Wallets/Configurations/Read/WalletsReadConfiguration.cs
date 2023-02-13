namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Wallets.Configurations.Read;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

internal class WalletsReadConfiguration : IEntityTypeConfiguration<WalletReadModel>
{
    public void Configure(EntityTypeBuilder<WalletReadModel> builder) => builder.ToTable(Constants.wallets);
}
