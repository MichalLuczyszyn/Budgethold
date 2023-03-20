namespace Budgethold.Shared.Abstractions.Kernel.ValueObjects.Transactions;

using System.Globalization;
using Currencies;
using Currencies.Exceptions;
using Exceptions;

public class Amount : ValueObject
{
    private decimal Value { get; }
    private string Currency { get; }
    private Amount(decimal value, string currency)
    {
        if (value <= 0)
            throw new ValueCannotBeLessThanZeroException();

        var isCurrencySupported = AvailableCurrencies.Currencies.Contains(currency);
        if (!isCurrencySupported) throw new CurrencyIsNotSupportedException();
        
        var currencyLimit = CurrenciesTransactionLimits.GetLimit(currency);
        var isCurrencyTransactionLimitSatisfied = value > currencyLimit; 
        
        if (isCurrencyTransactionLimitSatisfied)
            throw new ValueCannotBeGreaterThanException(currencyLimit, currency);

        Value = value;
        Currency = currency;
    }
    
    public static Amount Create(decimal value, string currency) => new(value, currency);
    public static Amount Create(Amount amount) => new(amount.TransactionAmount, amount.TransactionCurrency);
    
    public decimal TransactionAmount => Value;
    public string TransactionCurrency => Currency;

    public override string ToString() => Math.Round(Value, 2).ToString(CultureInfo.InvariantCulture) + " " + Currency;
}
