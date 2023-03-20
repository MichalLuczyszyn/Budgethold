namespace Budgethold.Modules.Wallets.Integration.Tests.Common.Fakers;

using Domain.Wallets.Entities;
using Domain.Wallets.ValueObjects;
using Shared.Abstractions.Kernel.Types;

internal static class WalletFaker
{
    internal static Wallet GetWallet(WalletId walletId) =>
        Wallet.Create(WalletId.Create(), Faker.Name.First(), WalletType.Private);
}
