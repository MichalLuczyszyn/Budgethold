using Microsoft.AspNetCore.Mvc;

namespace Budgethold.Modules.Wallets.Api.Controllers;

[ApiController]
[Route(BasePath + "/[controller]")]
internal class BaseController : ControllerBase
{
    private const string BasePath = "wallets-module";

    protected ActionResult<T> OkOrNotFound<T>(T model)
    {
        if (model is null)
            return NotFound();

        return Ok(model);
    }
}