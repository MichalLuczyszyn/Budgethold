namespace Budgethold.Modules.Wallets.Core.Commands.Wallets.Archive;

using Budgethold.Shared.Abstractions.Commands;

public record ArchiveWallet(Guid Id) : ICommand;
