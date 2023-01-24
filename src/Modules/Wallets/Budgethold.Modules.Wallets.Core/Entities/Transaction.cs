namespace Budgethold.Modules.Wallets.Core.Entities;

public class Transaction
{
    private Transaction()
    {
    }

    public Transaction(Guid id, string name, decimal amount, DateOnly date, Guid walletId)
    {
        Id = id;
        Name = name;
        Amount = amount;
        Date = date;
        WalletId = walletId;
    }

    public Guid Id { get; }

    public string Name { get; private set; }

    public decimal Amount { get; private set; }

    public DateOnly Date { get; private set; }

    public Guid WalletId { get; private set; }

    public Wallet Wallet { get; private set; }
}
