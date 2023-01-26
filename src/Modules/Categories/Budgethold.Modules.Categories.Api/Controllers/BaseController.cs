namespace Budgethold.Modules.Categories.Api.Controllers
{
    using Budgethold.Modules.Categories.Api;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route(CategoriesModule.BasePath + "/[controller]")]
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