namespace Budgethold.Modules.Categories.Infrastructure.DAL.Repositories;

using Budgethold.Modules.Categories.Core.Entities;
using Budgethold.Modules.Categories.Core.Repositories;
using Microsoft.EntityFrameworkCore;

internal class CategoryRepository : ICategoryRepository
{
    private readonly CategoriesDbContext _dbContext;
    private readonly DbSet<Category> _categories;

    public CategoryRepository(CategoriesDbContext dbContext)
    {
        _dbContext = dbContext;
        _categories = _dbContext.Categories;
    }

    public async Task<Category?> GetAsync(Guid id) => await _categories.FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(Category category)
    {
        _categories.Add(category);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _categories.Update(category);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Category category)
    {
        _categories.Remove(category);
        await _dbContext.SaveChangesAsync();
    }
}
