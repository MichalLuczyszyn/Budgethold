namespace Budgethold.Shared.Abstractions.Kernel.ValueObjects._Exceptions;

using Exceptions;

public class StringValueCannotBeNullOrEmptyException : BudgetholdException
{
    public string PropertyName { get; set; }
    public StringValueCannotBeNullOrEmptyException(string propertyName) : base($"{propertyName} cannot be null or empty") => PropertyName = propertyName;
}
