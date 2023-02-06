namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Wallets.Configurations.Read.Model;

using Transactions.Configurations.Read.Model;

internal sealed class WalletReadModel
{

    public Guid Id { get; init; }

    public string Name { get; init; }

    public ICollection<TransactionReadModel> Transactions { get; init; } = new List<TransactionReadModel>();
}
