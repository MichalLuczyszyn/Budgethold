namespace Budgethold.Modules.Wallets.Core.Commands.Update;

using Shared.Abstractions.Commands;

public record UpdateWallet(Guid Id, string Name) : ICommand;
