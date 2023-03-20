namespace Budgethold.Modules.Wallets.Domain.Wallets.ValueObjects;

internal static class Actions
{
    private static readonly string Read = nameof(Read);
    private static readonly string Create = nameof(Create);
    private static readonly string Archive = nameof(Archive);
    private static readonly string Update = nameof(Update);

    private static readonly List<string> AvailableActions = new List<string>() { Create, Archive, Update, Read };

    public static List<string> GetAvailableActions() => AvailableActions;
}

internal static class Resources
{
    private static readonly string Wallets = nameof(Wallets);
    private static readonly string Transactions = nameof(Transactions);
    private static readonly string RepeatableTransactions = nameof(RepeatableTransactions);
    private static readonly string Categories = nameof(Categories);
    private static readonly string Payments = nameof(Payments);
    private static readonly string TransactionLimits = nameof(TransactionLimits);

    private static readonly List<string> AvailableResources = new List<string>() { Wallets, Transactions, RepeatableTransactions, Categories, Payments, TransactionLimits };

    public static List<string> GetAvailableResources() => AvailableResources;
}

public class WalletRights
{
    public Dictionary<string, ICollection<string>> ResourceActionRight { get; set; }
}



