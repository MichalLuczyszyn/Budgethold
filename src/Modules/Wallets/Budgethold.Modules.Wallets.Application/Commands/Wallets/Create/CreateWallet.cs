namespace Budgethold.Modules.Wallets.Core.Commands.Wallets.Create;

using Budgethold.Shared.Abstractions.Commands;

public record CreateWallet(string Name) : ICommand<WalletCreatedResponse>;
