namespace Budgethold.Shared.Abstractions.Kernel.ValueObjects.Strings.Exceptions;

using Abstractions.Exceptions;

public class StringTooLongException : BudgetholdException
{
    public StringTooLongException() : base("This property cannot be longer than 100 characters")
    {
    }
}
