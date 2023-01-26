namespace Budgethold.Modules.Categories.Core.Services;

using Dtos;
using Shared.Infrastructure.Dtos;

public interface ICategoryService
{
    Task<CategoryResponseDto> GetAsync(Guid categoryId);
    Task<ObjectCreatedDto> CreateAsync(CategoryDto categoryDto);
    Task UpdateAsync(Guid categoryId, CategoryDto categoryDto);
    Task DeleteAsync(Guid categoryId);
}