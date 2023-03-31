namespace Budgethold.Modules.Wallets.Core.Commands.Categories.Create;

using Budgethold.Shared.Abstractions.Commands;

public record CreateCategory(Guid WalletId, string Name) : ICommand<CategoryCreatedResponse>;