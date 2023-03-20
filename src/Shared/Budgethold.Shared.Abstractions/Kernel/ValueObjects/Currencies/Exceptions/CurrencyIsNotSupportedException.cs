namespace Budgethold.Shared.Abstractions.Kernel.ValueObjects.Currencies.Exceptions;

using Abstractions.Exceptions;

public class CurrencyIsNotSupportedException : BudgetholdException
{
    public CurrencyIsNotSupportedException() : base($"Given currency is not supported")
    {
    }
}
