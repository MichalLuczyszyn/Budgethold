namespace Budgethold.Modules.Wallets.Infrastructure.DAL.RepeatableTransactions.Configurations.Read.Model;

using Transactions.Configurations.Read.Model;
using Wallets.Configurations.Read.Model;

internal class RepeatableTransactionReadModel
{
    public Guid Id { get; }

    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public decimal Amount { get; set; }
    public string Currency { get; set; }

    public DateOnly Date { get; set; }
    public string TransactionType { get; set; }

    public Guid WalletId { get; set; }

    public WalletReadModel Wallet { get; set; }
    
    public DateOnly StartsAt { get; set; }
    public short Interval { get; set; }
    
    public ICollection<TransactionReadModel> Transactions { get; set; } 
}
