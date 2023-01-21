using Microsoft.AspNetCore.Mvc;

namespace Budgethold.Modules.Wallets.Api.Controllers;

internal class HomeController : BaseController
{
    [HttpGet] 
    public ActionResult<string> Get() => "Wallets API";
}