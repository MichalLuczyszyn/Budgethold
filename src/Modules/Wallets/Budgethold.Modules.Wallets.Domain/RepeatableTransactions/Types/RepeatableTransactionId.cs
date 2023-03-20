namespace Budgethold.Modules.Wallets.Domain.RepeatableTransactions.Types;

using Shared.Abstractions.Kernel.Types;

internal class RepeatableTransactionId: TypeId
{
    public RepeatableTransactionId(Guid value) : base(value)
    {
    }
        
    public static RepeatableTransactionId Create() => new(Guid.NewGuid());
    public static implicit operator RepeatableTransactionId(Guid id) => new(id);
        
    public static implicit operator Guid(RepeatableTransactionId id) => id.Value;
}
