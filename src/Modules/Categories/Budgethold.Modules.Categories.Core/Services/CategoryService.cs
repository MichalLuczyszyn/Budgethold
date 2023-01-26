namespace Budgethold.Modules.Categories.Core.Services;

using Dtos;
using Entities;
using Exceptions;
using Repositories;
using Shared.Infrastructure.Dtos;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

    public async Task<CategoryResponseDto> GetAsync(Guid categoryId)
    {
        var category = await _categoryRepository.GetAsync(categoryId);

        if (category is null) throw new CategoryNotFoundException();

        return new CategoryResponseDto(category.Id, category.WalletId, category.Name);
    }

    public async Task<ObjectCreatedDto> CreateAsync(CategoryDto categoryDto)
    {
        var category = new Category(categoryDto.WalletId, categoryDto.Name);

        await _categoryRepository.AddAsync(category);

        return new ObjectCreatedDto(category.Id);
    }

    public async Task UpdateAsync(Guid categoryId, CategoryDto categoryDto)
    {
        var category = await _categoryRepository.GetAsync(categoryId);

        if (category is null) throw new CategoryNotFoundException();
        
        category.Update(categoryDto.Name);

        await _categoryRepository.UpdateAsync(category);
    }

    public async Task DeleteAsync(Guid categoryId)
    {
        var category = await _categoryRepository.GetAsync(categoryId);

        if (category is null) throw new CategoryNotFoundException();

        await _categoryRepository.DeleteAsync(category);
    }
}
