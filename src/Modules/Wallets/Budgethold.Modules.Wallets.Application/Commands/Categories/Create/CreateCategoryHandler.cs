namespace Budgethold.Modules.Wallets.Core.Commands.Categories.Create;

using Budgethold.Shared.Abstractions.Commands;
using Domain.Categories.Entities;
using Domain.Categories.Repositories;

internal class CreateCategoryHandler : ICommandHandler<CreateCategory, CategoryCreatedResponse>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryHandler(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public async Task<CategoryCreatedResponse> HandleAsync(CreateCategory command, CancellationToken cancellationToken = default)
    {
        var category = new Category(command.WalletId, command.Name);

        await _categoryRepository.AddAsync(category);

        return new CategoryCreatedResponse(category.Id);
    }
}
