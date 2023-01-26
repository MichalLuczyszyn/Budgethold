namespace Budgethold.Modules.Categories.Core.Entities;

public class Category
{
    private Category()
    {
        
    }
    public Category(Guid walletId, string name)
    {
        Id = Guid.NewGuid();
        WalletId = walletId;
        Name = name;
    }
    public Guid Id { get; private set; }
    public Guid WalletId { get; private set; }
    public string Name { get; private set; }

    internal void Update(string name) => Name = name;
}
