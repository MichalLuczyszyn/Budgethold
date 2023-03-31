namespace Budgethold.Modules.Wallets.Domain.Categories.Entities;

using RepeatableTransactions.Entities;
using Shared.Abstractions.Kernel.ValueObjects.Texts;
using Transactions.Entities;
using Types;
using Wallets.Entities;

internal class Category
{
    private Category()
    {
        
    }
    public Category(Guid walletId, string name)
    {
        Id = Guid.NewGuid();
        WalletId = walletId;
        Name = ShortText.Create(name, nameof(Name));
        Wallet = null!;
        RepeatableTransactions = new List<RepeatableTransaction>();
        Transactions = new List<Transaction>();
    }
    public CategoryId Id { get; private set; }
    
    public ShortText Name { get; private set; }
    
    private DateTimeOffset CreatedAt { get; set; }
    private DateTimeOffset? ArchivedAt { get; set; }
    
    public Guid WalletId { get; private set; }
    public Wallet Wallet { get; private set; }
    
    public ICollection<RepeatableTransaction> RepeatableTransactions { get; private set; }
    public ICollection<Transaction> Transactions { get; private set; }

    internal void Update(string name) => Name = ShortText.Create(name, nameof(Name));
    
    public void Archive(DateTimeOffset dateTimeOffset) => ArchivedAt = dateTimeOffset;
}
