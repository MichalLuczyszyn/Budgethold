namespace Budgethold.Modules.Categories.Application.Commands.Update;

using Core.Repositories;
using Shared.Abstractions.Commands;

public class UpdateCategoryHandler : ICommandHandler<UpdateCategory>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryHandler(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public Task HandleAsync(UpdateCategory command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
