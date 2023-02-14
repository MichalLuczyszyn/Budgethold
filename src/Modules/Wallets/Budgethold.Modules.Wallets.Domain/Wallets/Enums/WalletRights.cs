namespace Budgethold.Modules.Wallets.Domain.Wallets.Enums;

using System.Text.Json;

internal static class Actions
{
    private static readonly string Create = nameof(Create);
    private static readonly string Delete = nameof(Delete);
    private static readonly string Update = nameof(Update);

    private static readonly List<string> AvailableActions = new List<string>() { Create, Delete, Update };

    public static List<string> GetAvailableActions() => AvailableActions;
}

internal static class Resources
{
    private static readonly string Wallets = nameof(Wallets);
    private static readonly string Transactions = nameof(Transactions);
    private static readonly string RepeatableTransactions = nameof(RepeatableTransactions);
    private static readonly string Categories = nameof(Categories);

    private static readonly List<string> AvailableResources = new List<string>() { Wallets, Transactions, RepeatableTransactions, Categories };

    public static List<string> GetAvailableResources() => AvailableResources;
}

public class WalletRights
{
    public Dictionary<string, ICollection<string>> ResourceActionRight { get; set; }

    public string Serialize() => JsonSerializer.Serialize(ResourceActionRight);
}



