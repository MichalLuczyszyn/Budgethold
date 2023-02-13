namespace Budgethold.Modules.Wallets.Domain.Transactions.Entities;

using Wallets.Entities;

internal class Transaction
{
    private Transaction()
    {
        Wallet = null!;
        Name = null!;
        Description = null!;
    }

    private Transaction(string name, string description, decimal amount, DateOnly date, Guid walletId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Amount = amount;
        Date = date;
        WalletId = walletId;
        Wallet = null!;
    }

    public Guid Id { get; }

    public string Name { get; private set; }
    
    public string Description { get; private set; }

    public decimal Amount { get; private set; }

    public DateOnly Date { get; private set; }

    public Guid WalletId { get; private set; }

    public Wallet Wallet { get; private set; }

    public static Transaction Create(string name, string description, decimal amount, DateOnly date, Guid wallet) =>
        new Transaction(name, description, amount, date, wallet);
}
