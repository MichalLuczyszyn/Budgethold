namespace Budgethold.Shared.Abstractions.Kernel.ValueObjects.Texts;

using _Exceptions;
using GlobalRegexs;

public record LongText
{
    public string Value { get; }

    private const int CharactersLimit = 500;

    public LongText(string value) => Value = value;

    public LongText(string value, string propertyName)
    {
        if (value.Length > CharactersLimit)
            throw new StringValueCannotBeLongerThanException(propertyName, CharactersLimit);

        var isValueHavingForbiddenCharacters = GlobalRegex.DoesMatchRegex(value);
        if (isValueHavingForbiddenCharacters)
            throw new StringValueContainsInvalidCharactersException(propertyName);

        Value = value;
    }

    public static implicit operator string(LongText value) => value.Value;
    
    public static LongText Create(string value, string propertyName) => value is null ? null : new(value, propertyName);
    
    public override string ToString() => Value;
    public string ToLowerInvariant() => Value.ToLowerInvariant();
}
