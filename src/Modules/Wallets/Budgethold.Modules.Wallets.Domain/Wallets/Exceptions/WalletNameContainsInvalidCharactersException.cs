namespace Budgethold.Modules.Wallets.Domain.Wallets.Exceptions;

using Budgethold.Shared.Abstractions.Exceptions;

public class WalletNameContainsInvalidCharactersException : BudgetholdException
{
    public WalletNameContainsInvalidCharactersException() : base("Property contains invalid characters, only a-z, A-Z, äöüßÄÖÜ, ąćęłńóśźżĄĆĘŁŃÓŚŹŻ characters are valid")
    {
    }
}
