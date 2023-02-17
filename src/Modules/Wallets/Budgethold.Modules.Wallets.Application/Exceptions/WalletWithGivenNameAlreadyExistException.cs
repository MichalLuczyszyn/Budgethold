namespace Budgethold.Modules.Wallets.Core.Exceptions;

using Budgethold.Shared.Abstractions.Exceptions;

public class WalletWithGivenNameAlreadyExistException : BudgetholdException
{
    public WalletWithGivenNameAlreadyExistException() : base("Wallet with given name already exist")
    {
    }
}
