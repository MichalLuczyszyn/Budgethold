namespace Budgethold.Shared.Abstractions.Kernel.Types;

public class WalletId : TypeId
{
    public WalletId(Guid id) : base(id)
    {
    }

    public static WalletId Create() => new(Guid.NewGuid());
    public static implicit operator WalletId(Guid id) => new(id);
}
