namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Wallets.Exceptions;

using Shared.Abstractions.Exceptions;

public class WalletNotFoundException : BudgetholdException
{
    public WalletNotFoundException() : base("Wallet was not found")
    {
    }
}
