namespace Budgethold.Modules.Wallets.Domain.Categories.Exceptions;

using Budgethold.Shared.Abstractions.Exceptions;

public class CategoryNotFoundException : BudgetholdException
{
    public CategoryNotFoundException() : base("Category was not found")
    {
    }
}
