namespace Budgethold.Modules.Wallets.Api.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
internal class CategoriesController : BaseController
{
    // [HttpGet("{id:guid}")]
    // [ProducesResponseType(200)]
    // [ProducesResponseType(404)]
    // public async Task<ActionResult<CategoryResponseDto>> GetCategory([FromRoute] Guid id) => NoContent();
    //
    // [HttpPost]
    // [ProducesResponseType(200)]
    // [ProducesResponseType(404)]
    // public async Task<IActionResult> CreateCategory([FromBody] CategoryDto walletDto)
    // {
    //     return NoContent();
    // }
    //
    // [HttpPut("{id:guid}")]
    // [ProducesResponseType(204)]
    // [ProducesResponseType(404)]
    // public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] CategoryDto walletDto)
    // {
    //     return NoContent();
    // }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
    {

        return NoContent();
    }
}
