namespace Budgethold.Shared.Abstractions.Kernel.ValueObjects.Strings.Exceptions;

using Abstractions.Exceptions;

public class StringContainsInvalidCharactersException : BudgetholdException
{
    public StringContainsInvalidCharactersException() : base("Property contains invalid characters")
    {
    }
}
