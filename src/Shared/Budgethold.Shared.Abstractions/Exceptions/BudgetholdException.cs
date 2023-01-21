namespace Budgethold.Shared.Abstractions.Exceptions;

public abstract class BudgetholdException : Exception
{
    protected BudgetholdException(string message) : base(message)
    {
    }
}