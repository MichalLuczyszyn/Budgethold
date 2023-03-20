namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Transactions.Configurations.Read.Model;

using RepeatableTransactions.Configurations.Read.Model;
using Wallets.Configurations.Read.Model;

internal sealed class TransactionReadModel
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public decimal Amount { get; set; }
    
    public string Currency { get; set; }

    public DateOnly Date { get; init; }
    
    public string TransactionType { get; set; }
    
    public Guid WalletId { get; init; }

    public WalletReadModel Wallet { get; init; }    
    
    public Guid? RepeatableTransactionId { get; init; }

    public RepeatableTransactionReadModel? RepeatableTransaction { get; init; }
}
