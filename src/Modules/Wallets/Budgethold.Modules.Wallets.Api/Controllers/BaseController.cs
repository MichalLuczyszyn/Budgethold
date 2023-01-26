using Microsoft.AspNetCore.Mvc;

namespace Budgethold.Modules.Wallets.Api.Controllers;

using Shared.Infrastructure.Api;

[ApiController]
[ProducesDefaultContentType]
[Route(WalletsModule.BasePath + "/[controller]")]
internal class BaseController : ControllerBase
{
    protected ActionResult<T> OkOrNotFound<T>(T model)
    {
        if (model is null)
            return NotFound();

        return Ok(model);
    }
}