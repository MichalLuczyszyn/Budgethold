namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Transactions.Configurations.Read.Model;

using Wallets.Configurations.Read.Model;

internal sealed class TransactionReadModel
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public decimal Amount { get; init; }

    public DateOnly Date { get; init; }

    public Guid WalletId { get; init; }

    public WalletReadModel Wallet { get; init; }
}
