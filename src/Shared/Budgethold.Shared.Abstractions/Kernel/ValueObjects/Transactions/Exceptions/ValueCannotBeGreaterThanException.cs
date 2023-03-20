namespace Budgethold.Shared.Abstractions.Kernel.ValueObjects.Transactions.Exceptions;

using Abstractions.Exceptions;

public class ValueCannotBeGreaterThanException : BudgetholdException
{
    public decimal Amount { get; }
    public string Currency { get; }
    public ValueCannotBeGreaterThanException(decimal amount, string currency) : base($"Transaction amount cannot be greater than {amount} {currency}")
    {
        Amount = amount;
        Currency = currency;
    }
}
