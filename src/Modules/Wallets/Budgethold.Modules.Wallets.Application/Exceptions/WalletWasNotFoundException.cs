namespace Budgethold.Modules.Wallets.Core.Exceptions;

using Budgethold.Shared.Abstractions.Exceptions;

public class WalletWasNotFoundException : BudgetholdException
{
    public WalletWasNotFoundException() : base("Wallet was not found")
    {
    }
}
