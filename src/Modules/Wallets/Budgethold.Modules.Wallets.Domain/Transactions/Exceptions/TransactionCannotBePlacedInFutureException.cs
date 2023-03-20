namespace Budgethold.Modules.Wallets.Domain.Transactions.Exceptions;

using Shared.Abstractions.Exceptions;

public class TransactionCannotBePlacedInFutureException : BudgetholdException
{
    public TransactionCannotBePlacedInFutureException() : base("This transaction can not be placed in future")
    {
    }
}
