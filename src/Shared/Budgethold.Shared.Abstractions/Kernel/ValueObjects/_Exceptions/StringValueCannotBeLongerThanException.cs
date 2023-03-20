namespace Budgethold.Shared.Abstractions.Kernel.ValueObjects._Exceptions;

using Exceptions;

public class StringValueCannotBeLongerThanException : BudgetholdException
{
    public StringValueCannotBeLongerThanException(string propertyName, int charactersLimit) : base($"{propertyName} cannot be longer than {charactersLimit} characters")
    {
    }
}
