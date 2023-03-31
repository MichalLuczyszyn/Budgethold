namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Wallets.Configurations.Read.Model;

using Categories.Configurations.Read.Model;
using RepeatableTransactions.Configurations.Read.Model;
using Transactions.Configurations.Read.Model;

internal sealed class WalletReadModel
{

    public Guid Id { get; init; }

    public string Name { get; init; }
    public string WalletType { get; init; }

    public DateTimeOffset? ArchivedAt { get; private set; }
    
    public ICollection<RepeatableTransactionReadModel> RepeatableTransactions { get; private set; } = new List<RepeatableTransactionReadModel>();

    public ICollection<TransactionReadModel> Transactions { get; init; } = new List<TransactionReadModel>();
    public ICollection<CategoryReadModel> Categories { get; init; } = new List<CategoryReadModel>();
}
