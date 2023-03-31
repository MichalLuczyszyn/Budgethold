namespace Budgethold.Modules.Wallets.Domain.Categories.Types;

using Shared.Abstractions.Kernel.Types;

public class CategoryId : TypeId
{
    public CategoryId(Guid value) : base(value)
    {
    }

    public static CategoryId Create() => new(Guid.NewGuid());
    public static implicit operator CategoryId(Guid id) => new(id);

    public static implicit operator Guid(CategoryId id) => id.Value;
}
