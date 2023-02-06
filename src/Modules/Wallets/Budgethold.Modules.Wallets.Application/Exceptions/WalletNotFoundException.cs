namespace Budgethold.Modules.Wallets.Core.Exceptions;

using Shared.Abstractions.Exceptions;

public class WalletNotFoundException : BudgetholdException
{
    public WalletNotFoundException() : base("Wallet was not found")
    {
    }
}
