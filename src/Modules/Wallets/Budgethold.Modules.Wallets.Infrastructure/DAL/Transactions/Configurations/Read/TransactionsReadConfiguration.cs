namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Transactions.Configurations.Read;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

internal class TransactionsReadConfiguration : IEntityTypeConfiguration<TransactionReadModel>
{
    public void Configure(EntityTypeBuilder<TransactionReadModel> builder) => builder.ToTable(Constants.transactions);
}