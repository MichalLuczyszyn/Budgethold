namespace Budgethold.Modules.Wallets.Core.Commands.Wallets.Update;

using Budgethold.Shared.Abstractions.Commands;

public record UpdateWallet(Guid Id, string Name) : ICommand;

public record UpdateWalletRequest(string Name);
