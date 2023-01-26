namespace Budgethold.Modules.Categories.Api.Controllers;

using Budgethold.Modules.Categories.Core.Dtos;
using Budgethold.Modules.Categories.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
internal class CategoriesController : BaseController
{
    private readonly ICategoryService _categoryService;


    public CategoriesController(ICategoryService categoryService) => _categoryService = categoryService;

    [HttpGet("{id:guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<CategoryResponseDto>> GetCategory([FromRoute] Guid id) => OkOrNotFound(await _categoryService.GetAsync(id));

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryDto walletDto)
    {
        var response =  await _categoryService.CreateAsync(walletDto);
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] CategoryDto walletDto)
    {
        await _categoryService.UpdateAsync(id, walletDto);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
    {
        await _categoryService.DeleteAsync(id);

        return NoContent();
    }
}
