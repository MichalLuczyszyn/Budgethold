namespace Budgethold.Modules.Wallets.Domain.RepeatableTransactions.ValueObjects;

using Budgethold.Modules.Wallets.Domain.Wallets.Exceptions;
using Budgethold.Shared.Abstractions.Kernel.ValueObjects;
using Shared.Abstractions.Kernel.GlobalRegexs;

public class RepeatableTransactionName : ValueObject
{
    private string Value { get; }

    private RepeatableTransactionName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new WalletNameCannotBeNullOrEmptyException();

        if (value.Length > 100)
            throw new WalletNameTooLongException();
        
        var isValueHavingForbiddenCharacters = GlobalRegex.DoesMatchRegex(value);
        if (isValueHavingForbiddenCharacters)
            throw new WalletNameContainsInvalidCharactersException();

        Value = value;
    }

    public static implicit operator string(RepeatableTransactionName value) => value.Value;
    public static implicit operator RepeatableTransactionName(string value) => new RepeatableTransactionName(value);
    public override string ToString() => Value;
    public string ToLowerInvariant() => Value.ToLowerInvariant();
}
