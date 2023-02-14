namespace Budgethold.Modules.Wallets.Domain.Wallets.Exceptions;

using Budgethold.Shared.Abstractions.Exceptions;

public class StringContainsInvalidCharactersException : BudgetholdException
{
    public StringContainsInvalidCharactersException() : base("Property contains invalid characters")
    {
    }
}
