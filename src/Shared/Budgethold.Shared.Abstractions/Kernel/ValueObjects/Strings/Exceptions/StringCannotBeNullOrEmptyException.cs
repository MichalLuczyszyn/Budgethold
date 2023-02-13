namespace Budgethold.Shared.Abstractions.Kernel.ValueObjects.Strings.Exceptions;

using Abstractions.Exceptions;

public class StringCannotBeNullOrEmptyException : BudgetholdException
{
    public StringCannotBeNullOrEmptyException() : base("This property cannot be null or empty")
    {
    }
}
