namespace Budgethold.Shared.Abstractions.Kernel.ValueObjects._Exceptions;

using Exceptions;

public class StringValueCannotBeShorterThanException : BudgetholdException
{
    public StringValueCannotBeShorterThanException(string propertyName, int charactersLimit) : base($"{propertyName} cannot be shorter than {charactersLimit} characters")
    {
    }
}
