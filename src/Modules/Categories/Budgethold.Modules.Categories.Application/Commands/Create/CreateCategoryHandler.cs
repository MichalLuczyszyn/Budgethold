namespace Budgethold.Modules.Categories.Application.Commands.Create;

using Core.Entities;
using Core.Repositories;
using Shared.Abstractions.Commands;

public class CreateCategoryHandler : ICommandHandler<CreateCategory, CategoryCreated>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryHandler(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public async Task<CategoryCreated> HandleAsync(CreateCategory command, CancellationToken cancellationToken = default)
    {
        var category = new Category(command.WalletId, command.Name);

        await _categoryRepository.AddAsync(category);

        return new CategoryCreated(category.Id);
    }
}
