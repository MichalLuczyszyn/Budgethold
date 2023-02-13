namespace Budgethold.Modules.Wallets.Domain.RepeatableTransactions.Entities;

using Wallets.Entities;

internal class RepeatableTransaction
{
    private RepeatableTransaction()
    {
        Wallet = null!;
        Name = null!;
    }
    private RepeatableTransaction(string name, string description, decimal amount, DateOnly date, Guid walletId, DateOnly startsAt, short interval)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Amount = amount;
        Date = date;
        WalletId = walletId;
        Wallet = null!;
        StartsAt = startsAt;
        Interval = interval;
    }
    public Guid Id { get; }

    public string Name { get; private set; }
    
    public string? Description { get; private set; }

    public decimal Amount { get; private set; }

    public DateOnly Date { get; private set; }

    public Guid WalletId { get; private set; }

    public Wallet Wallet { get; private set; }
    public DateOnly StartsAt { get; private set; }
    public short Interval { get; private set; }
    
    public static RepeatableTransaction Create(string name, string description, decimal amount, DateOnly date, Guid walletId, DateOnly startsAt, short interval) =>
        new RepeatableTransaction(name, description, amount, date, walletId, startsAt, interval);
}
