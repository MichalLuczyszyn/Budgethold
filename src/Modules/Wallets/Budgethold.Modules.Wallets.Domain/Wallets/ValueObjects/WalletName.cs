namespace Budgethold.Modules.Wallets.Domain.Wallets.ValueObjects;

using System.Text.RegularExpressions;
using Exceptions;
using Shared.Abstractions.Kernel.ValueObjects;

public partial class WalletName : ValueObject
{
    private static readonly Regex Regex = MyRegex();
    public string Value { get; }
    
    public WalletName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new WalletNameCannotBeNullOrEmptyException();

        if (value.Length > 100)
            throw new WalletNameTooLongException();

        value = value.ToLowerInvariant();
        if (!Regex.IsMatch(value))
            throw new StringContainsInvalidCharactersException();

        Value = value;
    }

    public static implicit operator string(WalletName value) => value.Value;
    public static implicit operator WalletName(string value) => new WalletName(value);
    public override string ToString() => Value;
    public string ToLowerInvariant() => Value.ToLowerInvariant();
    
    [GeneratedRegex("^[a-zA-Zęóąśłżźćń]+$", RegexOptions.Compiled)]
    private static partial Regex MyRegex();
}
