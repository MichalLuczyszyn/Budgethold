namespace Budgethold.Modules.Wallets.Core.Commands.Create;

using Shared.Abstractions.Commands;

public record CreateWallet(string Name) : ICommand<WalletCreatedResponse>;
