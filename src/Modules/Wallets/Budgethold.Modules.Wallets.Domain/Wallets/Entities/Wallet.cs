namespace Budgethold.Modules.Wallets.Domain.Wallets.Entities;

using Budgethold.Modules.Wallets.Domain.Transactions.Entities;
using Events;
using RepeatableTransactions.Entities;
using Shared.Abstractions.Kernel.Types;

internal class Wallet : AggregateRoot<WalletId>
{
    private Wallet() => Name = null!;

    private Wallet(string name)
    {
        Id = new WalletId(Guid.NewGuid());
        Name = name;
    }

    public WalletId Id { get; }

    public string Name { get; private set; }

    public ICollection<Transaction> Transactions { get; private set; } = new List<Transaction>();
    public ICollection<RepeatableTransaction> RepeatableTransactions { get; private set; } = new List<RepeatableTransaction>();

    public void Update(string name) => Name = name;

    public static Wallet Create(string name)
    {
        var wallet = new Wallet(name);
        
        wallet.AddEvent(new WalletCreated(wallet));
        return wallet;
    }
}
