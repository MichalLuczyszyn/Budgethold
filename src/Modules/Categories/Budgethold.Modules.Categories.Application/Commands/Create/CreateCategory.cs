namespace Budgethold.Modules.Categories.Application.Commands.Create;

using Budgethold.Shared.Abstractions.Commands;

public record CreateCategory(Guid WalletId, string Name) : ICommand<CategoryCreatedResponse>;