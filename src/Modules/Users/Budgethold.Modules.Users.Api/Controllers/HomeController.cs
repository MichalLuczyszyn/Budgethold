namespace Budgethold.Modules.Users.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Microsoft.AspNetCore.Components.Route(UsersModule.BasePath)]
    internal class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Get() => "Users API";
    }
}