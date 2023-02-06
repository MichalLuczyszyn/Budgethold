using Microsoft.AspNetCore.Mvc;

namespace Budgethold.Modules.Wallets.Api.Controllers;

using Core.Dtos;
using Microsoft.AspNetCore.Authorization;

[Authorize]
internal class WalletsController : BaseController
{
    [HttpGet("{id:guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<WalletResponseDto>> GetWallet([FromRoute] Guid id)
    {
        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> CreateWallet([FromBody] WalletDto walletDto)
    {
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateWallet([FromRoute] Guid id, [FromBody] WalletDto walletDto)
    {
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteWallet([FromRoute] Guid id)
    {
        return NoContent();
    }
}
