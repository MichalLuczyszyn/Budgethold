namespace Budgethold.Modules.Wallets.Domain.Wallets.Exceptions;

using Budgethold.Shared.Abstractions.Exceptions;

public class WalletNameTooLongException : BudgetholdException
{
    public WalletNameTooLongException() : base("Wallet name cannot be longer than 100 characters")
    {
    }
}
