namespace Budgethold.Shared.Abstractions.Kernel.ValueObjects.Currencies;

public static class AvailableCurrencies
{
    private static string PLN = nameof(PLN);
    private static string USD = nameof(USD);
    private static string EUR = nameof(EUR);

    public static List<string> Currencies = new List<string>() { PLN, USD, EUR };
}
