namespace Budgethold.Modules.Wallets.Domain.Wallets.Exceptions;

using Budgethold.Shared.Abstractions.Exceptions;

public class StringCannotBeNullOrEmptyException : BudgetholdException
{
    public StringCannotBeNullOrEmptyException() : base("This property cannot be null or empty")
    {
    }
}
