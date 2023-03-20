namespace Budgethold.Modules.Wallets.Domain.Wallets.Entities;

using Budgethold.Modules.Wallets.Domain.Transactions.Entities;
using Events;
using Exceptions;
using RepeatableTransactions.Entities;
using Shared.Abstractions.Kernel.Types;
using Transactions.Exceptions;
using Transactions.ValueObjects;
using ValueObjects;

internal class Wallet : AggregateRoot<WalletId>
{
    protected Wallet() => Name = null!;

    private Wallet(WalletId id,WalletName name, WalletType walletType)
    {
        Id = id;
        Name = name;
        WalletType = walletType;
    }

    public WalletName Name { get; private set; }
    public WalletType WalletType { get; private set; }
    private DateTimeOffset? ArchivedAt { get; set; }

    public ICollection<Transaction> Transactions { get; private set; } = new List<Transaction>();

    public ICollection<RepeatableTransaction> RepeatableTransactions { get; private set; } =
        new List<RepeatableTransaction>();

    private bool IsArchived => ArchivedAt.HasValue;

    public void Update(string name)
    {
        if (IsArchived) throw new WalletIsArchivedException();
        Name = name;
    }

    public void ShareWallet()
    {
        if (IsArchived) throw new WalletIsArchivedException();
        WalletType = WalletType.Shared;
    }

    public void PrivatizeWallet()
    {
        if (IsArchived) throw new WalletIsArchivedException();
        WalletType = WalletType.Private;
    }

    public void AddTransaction(Transaction transaction, DateOnly date)
    {
        if (IsArchived) throw new WalletIsArchivedException();

        if (transaction.TransactionType.Value == TransactionType.Future && transaction.Date < date)
            throw new FutureTransactionCannotBePlacedInPastException();

        if (transaction.TransactionType.Value == TransactionType.Standard && transaction.Date > date)
            throw new TransactionCannotBePlacedInFutureException();

        Transactions.Add(transaction);
    }

    public void Archive(DateTimeOffset dateTimeOffset)
    {
        ArchivedAt = dateTimeOffset;

        AddEvent(new WalletArchived(this));
    }

    public static Wallet Create(WalletId id,WalletName name, WalletType walletType)
    {
        var wallet = new Wallet(id, name, walletType);

        wallet.AddEvent(new WalletCreated(wallet));
        return wallet;
    }
}
