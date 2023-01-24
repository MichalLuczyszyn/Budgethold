namespace Budgethold.Modules.Users.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route(UsersModule.BasePath + "/[controller]")]
    internal abstract class BaseController : ControllerBase
    {
        protected ActionResult<T> OkOrNotFound<T>(T model)
        {
            if (model is not null)
            {
                return Ok(model);
            }

            return NotFound();
        }
    }
}