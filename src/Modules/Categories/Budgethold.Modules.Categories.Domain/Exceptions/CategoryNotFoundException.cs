namespace Budgethold.Modules.Categories.Core.Exceptions;

using Shared.Abstractions.Exceptions;

public class CategoryNotFoundException : BudgetholdException
{
    public CategoryNotFoundException() : base("Category was not found")
    {
    }
}
