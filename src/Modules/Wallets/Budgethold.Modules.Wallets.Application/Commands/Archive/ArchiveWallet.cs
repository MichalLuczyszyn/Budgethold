namespace Budgethold.Modules.Wallets.Core.Commands.Archive;

using Budgethold.Shared.Abstractions.Commands;

public record ArchiveWallet(Guid Id) : ICommand;
