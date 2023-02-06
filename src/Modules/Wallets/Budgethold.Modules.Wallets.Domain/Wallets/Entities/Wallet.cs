namespace Budgethold.Modules.Wallets.Domain.Wallets.Entities;

using Budgethold.Modules.Wallets.Domain.Transactions.Entities;

public class Wallet
{
    private Wallet()
    {
    }

    public Wallet(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public Guid Id { get; }

    public string Name { get; private set; }

    public ICollection<Transaction> Transactions { get; private set; } = new List<Transaction>();

    internal void Update(string name) => Name = name;
}
