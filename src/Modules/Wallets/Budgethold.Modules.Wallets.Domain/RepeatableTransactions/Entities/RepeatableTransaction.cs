﻿namespace Budgethold.Modules.Wallets.Domain.RepeatableTransactions.Entities;

using Shared.Abstractions.Kernel.Types;
using Shared.Abstractions.Kernel.ValueObjects.Currencies;
using Shared.Abstractions.Kernel.ValueObjects.Texts;
using Shared.Abstractions.Kernel.ValueObjects.Transactions;
using Transactions.Entities;
using Types;
using ValueObjects;
using Wallets.Entities;

internal class RepeatableTransaction
{
    private RepeatableTransaction()
    {
        Wallet = null!;
        Name = null!;
    }
    private RepeatableTransaction(RepeatableTransactionName name, string description, Amount amount, DateOnly date, Guid walletId, DateOnly startsAt, short interval, DateTimeOffset currentDate)
    {
        Id = RepeatableTransactionId.Create();
        Name = ShortText.Create(name, nameof(Name));
        Description = LongText.Create(description, nameof(Description));
        Amount = amount;
        Date = date;
        WalletId = walletId;
        Wallet = null!;
        StartsAt = startsAt;
        Interval = interval;
        CreatedAt = currentDate;
    }
    public RepeatableTransactionId Id { get; }

    public ShortText Name { get; private set; }
    
    public LongText Description { get; private set; }
    
    public Amount Amount { get; private set; }

    public DateOnly Date { get; private set; }

    public WalletId WalletId { get; private set; }
    private DateTimeOffset CreatedAt { get; set; }
    private DateTimeOffset? ArchivedAt { get; set; }

    public Wallet Wallet { get; private set; }
    public DateOnly StartsAt { get; private set; }
    public short Interval { get; private set; }
    
    public ICollection<Transaction> Transactions { get; private set; } 

    public static RepeatableTransaction Create(RepeatableTransactionName name, string description, Amount amount, DateOnly date, Guid walletId, DateOnly startsAt, short interval, DateTimeOffset currentDate) =>
        new RepeatableTransaction(name, description, amount, date, walletId, startsAt, interval, currentDate);
}
