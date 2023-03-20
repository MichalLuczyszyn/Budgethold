namespace Budgethold.Modules.Wallets.Domain.Wallets.Exceptions;

using Shared.Abstractions.Exceptions;

public class WalletIsArchivedException : BudgetholdException
{
    public WalletIsArchivedException() : base("Wallet is archived")
    {
    }
}
