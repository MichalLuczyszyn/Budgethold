namespace Budgethold.Modules.Wallets.Domain.Wallets.Exceptions;

using Budgethold.Shared.Abstractions.Exceptions;

public class WalletNameCannotBeNullOrEmptyException : BudgetholdException
{
    public WalletNameCannotBeNullOrEmptyException() : base("Name cannot be null or empty")
    {
    }
}
