using Microsoft.AspNetCore.Mvc;

namespace Budgethold.Modules.Wallets.Api.Controllers;

using Core.Commands.Wallets.Archive;
using Core.Commands.Wallets.Create;
using Core.Commands.Wallets.Update;
using Core.Queries.Wallet.Get;
using Core.Queries.Wallet.GetList;
using Microsoft.AspNetCore.Authorization;
using Shared.Abstractions.Commands;
using Shared.Abstractions.Queries;

[Authorize("wallets:read-write")]
internal class WalletsController : BaseController
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly ICommandDispatcher _commandDispatcher;

    public WalletsController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
    {
        _queryDispatcher = queryDispatcher;
        _commandDispatcher = commandDispatcher;
    }
    [HttpGet("{id:guid}")]
    [ProducesResponseType(200, Type = typeof(GetWalletResponse))]
    [ProducesResponseType(404)]
    public async Task<ActionResult<GetWalletResponse>> GetWallet([FromRoute] Guid id)
    {
        var query = new GetWallet(id);
        return OkOrNotFound(await _queryDispatcher.QueryAsync(query));
    }    
    
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(ICollection<GetWalletsResponse>))]
    [ProducesResponseType(404)]
    public async Task<ActionResult<ICollection<GetWalletsResponse>>> GetWallets()
    {
        var query = new GetWallets();
        return Ok(await _queryDispatcher.QueryAsync(query));
    }
    
    [HttpPost]
    [ProducesResponseType(200, Type = typeof(WalletCreatedResponse))]
    public async Task<IActionResult> CreateWallet([FromBody] CreateWallet walletDto) => Ok(await _commandDispatcher.SendAsync<CreateWallet, WalletCreatedResponse>(walletDto, new CancellationToken()));
    
    [HttpPut("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateWallet([FromRoute] Guid id, [FromBody] UpdateWalletRequest updateWalletRequest)
    {
        await _commandDispatcher.SendAsync(new UpdateWallet(id, updateWalletRequest.Name), new CancellationToken());
        
        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> ArchiveWallet([FromRoute] Guid id)
    {
        await _commandDispatcher.SendAsync(new ArchiveWallet(id), new CancellationToken());
        
        return NoContent();
    }
}
