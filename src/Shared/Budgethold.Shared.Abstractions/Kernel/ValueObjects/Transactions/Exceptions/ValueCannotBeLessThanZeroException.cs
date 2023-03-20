namespace Budgethold.Shared.Abstractions.Kernel.ValueObjects.Transactions.Exceptions;

using Abstractions.Exceptions;

public class ValueCannotBeLessThanZeroException : BudgetholdException
{
    public ValueCannotBeLessThanZeroException() : base("Transaction amount cannot be less or equal to zero")
    {
    }
}
