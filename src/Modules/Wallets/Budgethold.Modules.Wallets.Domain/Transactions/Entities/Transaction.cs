namespace Budgethold.Modules.Wallets.Domain.Transactions.Entities;

using Categories.Entities;
using Categories.Types;
using RepeatableTransactions.Entities;
using RepeatableTransactions.Types;
using Shared.Abstractions.Kernel.Types;
using Shared.Abstractions.Kernel.ValueObjects.Texts;
using Shared.Abstractions.Kernel.ValueObjects.Transactions;
using Types;
using ValueObjects;
using Wallets.Entities;

internal class Transaction
{
    private Transaction()
    {
        Wallet = null!;
        Name = null!;
        Description = null!;
    }

    private Transaction(TransactionName name, string description, Amount amount, DateOnly date, Guid walletId, Guid categoryId, TransactionType transactionType,
        DateTimeOffset currentDate)
    {
        Id = TransactionId.Create();
        Name = ShortText.Create(name, nameof(Name));
        Description = LongText.Create(description, nameof(Description));
        Amount = amount;
        Date = date;
        TransactionType = transactionType;
        WalletId = walletId;
        Wallet = null!;
        Category = null!;
        CategoryId = categoryId;
        CreatedAt = currentDate;
    }

    public TransactionId Id { get; }

    public ShortText Name { get; private set; }

    public LongText Description { get; private set; }

    public Amount Amount { get; private set; }

    public TransactionType TransactionType { get; private set; }

    public DateOnly Date { get; private set; }

    private DateTimeOffset CreatedAt { get; set; }

    private DateTimeOffset? ArchivedAt { get; set; }

    public WalletId WalletId { get; private set; }
    public Wallet Wallet { get; private set; }

    public CategoryId CategoryId { get; private set; }
    public Category Category { get; private set; }

    public RepeatableTransactionId? RepeatableTransactionId { get; private set; }
    public RepeatableTransaction? RepeatableTransaction { get; private set; }

    public static Transaction Create(TransactionName name, string description, Amount amount, DateOnly date,
        Guid walletId, Guid categoryId, TransactionType transactionType, DateTimeOffset currentDate) =>
        new Transaction(name, description, amount, date, walletId, categoryId, transactionType, currentDate);

    public void Archive(DateTimeOffset dateTimeOffset) => ArchivedAt = dateTimeOffset;
}
