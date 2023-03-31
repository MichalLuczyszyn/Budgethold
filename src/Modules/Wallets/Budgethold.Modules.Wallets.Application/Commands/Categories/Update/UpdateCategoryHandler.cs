namespace Budgethold.Modules.Wallets.Core.Commands.Categories.Update;

using Budgethold.Shared.Abstractions.Commands;
using Domain.Categories.Repositories;

internal class UpdateCategoryHandler : ICommandHandler<UpdateCategory>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryHandler(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public Task HandleAsync(UpdateCategory command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
