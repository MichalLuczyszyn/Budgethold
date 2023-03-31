namespace Budgethold.Shared.Abstractions.Kernel.ValueObjects.Texts;

using Budgethold.Shared.Abstractions.Kernel.GlobalRegexs;
using Budgethold.Shared.Abstractions.Kernel.ValueObjects._Exceptions;

public record ShortText
{
    public string Value { get; }

    private const int MinimumLengthName = 3;
    private const int MaximumLenghtName = 100;

    public ShortText(string value) => Value = value;

    private ShortText(string value, string propertyName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new StringValueCannotBeNullOrEmptyException(propertyName);

        switch (value.Length)
        {
            case > MaximumLenghtName:
                throw new StringValueCannotBeLongerThanException(propertyName, MaximumLenghtName);
            case < MinimumLengthName:
                throw new StringValueCannotBeShorterThanException(propertyName, MinimumLengthName);
        }

        var isValueHavingForbiddenCharacters = GlobalRegex.DoesMatchRegex(value);
        if (isValueHavingForbiddenCharacters)
            throw new StringValueContainsInvalidCharactersException(propertyName);

        Value = value;
    }

    public static implicit operator string(ShortText value) => value.Value;
    
    public static ShortText Create(string value, string propertyName) => new(value, propertyName);
    
    public override string ToString() => Value;
    public string ToLowerInvariant() => Value.ToLowerInvariant();
}
