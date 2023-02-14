namespace Budgethold.Modules.Wallets.Domain.Wallets.Entities;

using Budgethold.Modules.Wallets.Domain.Transactions.Entities;
using Events;
using RepeatableTransactions.Entities;
using Shared.Abstractions.Kernel.Types;
using ValueObjects;

internal class Wallet : AggregateRoot<WalletId>
{
    protected Wallet() => Name = null!;

    private Wallet(WalletName name, WalletType walletType)
    {
        Id = new WalletId(Guid.NewGuid());
        Name = name;
        WalletType = walletType;
    }

    public WalletId Id { get; }

    public WalletName Name { get; private set; }
    public WalletType WalletType { get; private set; }

    public ICollection<Transaction> Transactions { get; private set; } = new List<Transaction>();
    public ICollection<RepeatableTransaction> RepeatableTransactions { get; private set; } = new List<RepeatableTransaction>();

    public void Update(string name) => Name = name;
    public void ShareWallet() => WalletType = WalletType.Shared;
    public void PrivatizeWallet() => WalletType = WalletType.Private;

    public static Wallet Create(WalletName name, WalletType walletType)
    {
        var wallet = new Wallet(name, walletType);
        
        wallet.AddEvent(new WalletCreated(wallet));
        return wallet;
    }
}
