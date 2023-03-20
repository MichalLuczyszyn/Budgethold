namespace Budgethold.Modules.Wallets.Domain.Transactions.ValueObjects;

using Shared.Abstractions.Kernel.ValueObjects;

public class TransactionType : ValueObject
{
    public string Value { get; }

    public TransactionType(){}
    public TransactionType(string name) => Value = name;

    internal static TransactionType Standard => new(nameof(Standard));
    internal static TransactionType Repeatable => new(nameof(Repeatable));
    internal static TransactionType Future => new(nameof(Future));
    
    public static implicit operator string(TransactionType walletType) => walletType.Value;
}
