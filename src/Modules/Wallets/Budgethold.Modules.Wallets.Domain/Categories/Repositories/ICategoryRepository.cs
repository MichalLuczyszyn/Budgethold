namespace Budgethold.Modules.Wallets.Domain.Categories.Repositories;

using Entities;

internal interface ICategoryRepository
{
    Task<Category?> GetAsync(Guid id);

    Task AddAsync(Category wallet);

    Task UpdateAsync(Category wallet);

    Task DeleteAsync(Category wallet);
}
