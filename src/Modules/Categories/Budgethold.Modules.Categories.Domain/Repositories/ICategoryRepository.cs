namespace Budgethold.Modules.Categories.Core.Repositories;

using Entities;

public interface ICategoryRepository
{
    Task<Category?> GetAsync(Guid id);

    Task AddAsync(Category wallet);

    Task UpdateAsync(Category wallet);

    Task DeleteAsync(Category wallet);
}
