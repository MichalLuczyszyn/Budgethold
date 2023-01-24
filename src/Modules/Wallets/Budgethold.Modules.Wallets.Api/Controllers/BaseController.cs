using Microsoft.AspNetCore.Mvc;

namespace Budgethold.Modules.Wallets.Api.Controllers;

[ApiController]
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