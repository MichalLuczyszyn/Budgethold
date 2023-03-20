namespace Budgethold.Modules.Wallets.Domain.Transactions.Types;

using Shared.Abstractions.Kernel.Types;

internal class TransactionId : TypeId
{
    public TransactionId(Guid value) : base(value)
    {
    }
        
    public static TransactionId Create() => new(Guid.NewGuid());
    public static implicit operator TransactionId(Guid id) => new(id);
        
    public static implicit operator Guid(TransactionId id) => id.Value;
}
