using Microsoft.AspNetCore.Mvc;

namespace Budgethold.Modules.Wallets.Api.Controllers;

using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Authorization;

[Authorize]
internal class WalletsController : BaseController
{
    private readonly IWalletService _walletService;

    public WalletsController(IWalletService walletService) => _walletService = walletService;

    [HttpGet("{id:guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<WalletResponseDto>> GetWallet([FromRoute] Guid id) => OkOrNotFound(await _walletService.GetAsync(id));

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> CreateWallet([FromBody] WalletDto walletDto)
    {
        var response = await _walletService.CreateAsync(walletDto);
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateWallet([FromRoute] Guid id, [FromBody] WalletDto walletDto)
    {
        await _walletService.UpdateAsync(id, walletDto);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteWallet([FromRoute] Guid id)
    {
        await _walletService.DeleteAsync(id);

        return NoContent();
    }
}
