namespace Budgethold.Modules.Wallets.Domain.Transactions.Exceptions;

using Shared.Abstractions.Exceptions;

public class FutureTransactionCannotBePlacedInPastException : BudgetholdException
{
    public FutureTransactionCannotBePlacedInPastException() : base("Future transaction can not be placed in past")
    {
    }
}
