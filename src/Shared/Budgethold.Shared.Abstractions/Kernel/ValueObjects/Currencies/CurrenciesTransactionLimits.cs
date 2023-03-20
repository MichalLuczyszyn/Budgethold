namespace Budgethold.Shared.Abstractions.Kernel.ValueObjects.Currencies;

using System.Reflection;

public static class CurrenciesTransactionLimits
{
    private static decimal PLN = 100_000;
    private static decimal USD = 50_000;
    private static decimal EUR = 50_000;

    private const decimal DefaultLimit = 100_000;


    private static Dictionary<string, decimal> _limits;

    static CurrenciesTransactionLimits() => PopulateLimits();

    public static Dictionary<string, decimal> GetLimits()
    {
        if (_limits != null) return _limits;
        
        _limits = new Dictionary<string, decimal>();
        PopulateLimits();
        return _limits;
    }

    public static decimal GetLimit(string currency)
    {
        var limits = GetLimits();
        
        limits.TryGetValue(currency, out var limit);
        
        return limit == 0 ? DefaultLimit : limit;
    }
    
    

    private static void PopulateLimits()
    {
        var fields = typeof(CurrenciesTransactionLimits).GetFields(BindingFlags.NonPublic | BindingFlags.Static);
        foreach (var field in fields)
        {
            var fieldName = field.Name;
            var fieldValue = (decimal)field.GetValue(null);
            _limits[fieldName] = fieldValue;
        }
    }
}

