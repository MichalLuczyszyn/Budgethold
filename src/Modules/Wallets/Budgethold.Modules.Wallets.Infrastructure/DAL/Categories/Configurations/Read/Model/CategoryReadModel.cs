namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Categories.Configurations.Read.Model;

using RepeatableTransactions.Configurations.Read.Model;
using Transactions.Configurations.Read.Model;
using Wallets.Configurations.Read.Model;

internal sealed class CategoryReadModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? ArchivedAt { get; set; }
    
    public Guid WalletId { get; set; }
    public WalletReadModel Wallet { get; set; }
    
    public ICollection<RepeatableTransactionReadModel> RepeatableTransactions { get; set; }
    
    public ICollection<TransactionReadModel> Transactions { get; set; }
}
