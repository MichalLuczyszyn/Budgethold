namespace Budgethold.Modules.Wallets.Infrastructure.DAL.Categories.Repositories;

using Context;
using Domain.Categories.Entities;
using Domain.Categories.Repositories;
using Microsoft.EntityFrameworkCore;

internal class CategoryRepository : ICategoryRepository
{
    private readonly WalletsWriteDbContext _dbContext;
    private readonly DbSet<Category> _categories;

    public CategoryRepository(WalletsWriteDbContext dbContext)
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
