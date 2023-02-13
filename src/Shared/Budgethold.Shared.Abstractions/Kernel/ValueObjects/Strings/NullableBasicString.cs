namespace Budgethold.Shared.Abstractions.Kernel.ValueObjects.Strings;

using System.Text.RegularExpressions;
using Exceptions;

public partial class NullableBasicString : ValueObject
{
    private const string RegexPattern = @"^[a-zA-Zęóąśłżźćń]+$";
    public string Value { get; }

    public NullableBasicString(string value)
    {
        if (value.Length > 100)
            throw new StringTooLongException();

        value = value.ToLowerInvariant();
        if (!MyRegex().IsMatch(value))
            throw new StringContainsInvalidCharactersException();

        Value = value;
    }

    public static implicit operator string(NullableBasicString value) => value?.Value;

    public static implicit operator NullableBasicString(string value) =>
        value is null ? null : new NullableBasicString(value);

    public override string ToString() => Value;
    [GeneratedRegex("^[a-zA-Zęóąśłżźćń]+$")]
    private static partial Regex MyRegex();
}