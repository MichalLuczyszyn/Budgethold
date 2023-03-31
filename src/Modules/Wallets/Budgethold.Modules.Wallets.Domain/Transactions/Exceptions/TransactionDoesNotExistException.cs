namespace Budgethold.Modules.Wallets.Domain.Transactions.Exceptions;

using Shared.Abstractions.Exceptions;

public class TransactionDoesNotExistException : BudgetholdException
{
    public TransactionDoesNotExistException() : base("Transaction does not exist or you don't have access to it")
    {
    }
}
