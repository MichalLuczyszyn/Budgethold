namespace Budgethold.Shared.Abstractions.Kernel.ValueObjects._Exceptions;

using Exceptions;

public class StringValueContainsInvalidCharactersException : BudgetholdException
{
    public StringValueContainsInvalidCharactersException(string propertyName) : base($"{propertyName} contains invalid characters")
    {
    }
}
