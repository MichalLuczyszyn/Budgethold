namespace Budgethold.Shared.Abstractions.Kernel.ValueObjects.Currencies;

using Exceptions;

public class Currency : ValueObject
{
    public string Value { get; }

    public Currency(string currency)
    {
        var isCurrencySupported = AvailableCurrencies.Currencies.Contains(currency);
        if (!isCurrencySupported) throw new CurrencyIsNotSupportedException();

        Value = currency;
    }
    
    public static implicit operator string(Currency value) => value.Value;
    public static implicit operator Currency(string value) => new(value);

    public override string ToString() => Value;
}
