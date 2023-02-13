namespace Budgethold.Shared.Abstractions.Kernel.ValueObjects.Strings;

using System.Text.RegularExpressions;
using Exceptions;

public partial class BasicString : ValueObject
{
    private static readonly Regex Regex = MyRegex();
    public string Value { get; }
    
    public BasicString(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new StringCannotBeNullOrEmptyException();

        if (value.Length > 100)
            throw new StringTooLongException();

        value = value.ToLowerInvariant();
        if (!Regex.IsMatch(value))
            throw new StringContainsInvalidCharactersException();

        Value = value;
    }

    public static implicit operator string(BasicString value) => value.Value;
    public static implicit operator BasicString(string value) => new BasicString(value);
    public override string ToString() => Value;
    
    [GeneratedRegex("^[a-zA-Zęóąśłżźćń]+$", RegexOptions.Compiled)]
    private static partial Regex MyRegex();
}
