namespace Budgethold.Modules.Wallets.Domain.Wallets.ValueObjects;

using Exceptions;
using Shared.Abstractions.Kernel.GlobalRegexs;
using Shared.Abstractions.Kernel.ValueObjects;

public sealed class WalletName : ValueObject
{
    public string Value { get; }

    public WalletName(string value)
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

    public static implicit operator string(WalletName value) => value.Value;
    public static implicit operator WalletName(string value) => new WalletName(value);
    public override string ToString() => Value;
    public string ToLowerInvariant() => Value.ToLowerInvariant();
}
