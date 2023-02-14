namespace Budgethold.Modules.Wallets.Domain.Wallets.Exceptions;

using Budgethold.Shared.Abstractions.Exceptions;

public class StringTooLongException : BudgetholdException
{
    public StringTooLongException() : base("This property cannot be longer than 100 characters")
    {
    }
}
