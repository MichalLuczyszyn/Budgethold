namespace Budgethold.Modules.Wallets.Domain.Wallets.ValueObjects;

using Shared.Abstractions.Kernel.ValueObjects;

internal class WalletType : ValueObject
{
    public string Value { get; }

    private WalletType(){}
    private WalletType(string name) => Value = name;

    internal static WalletType Shared => new(nameof(Shared));
    internal static WalletType Private => new(nameof(Private));
    
    public static implicit operator string(WalletType walletType) => walletType.Value;
}
