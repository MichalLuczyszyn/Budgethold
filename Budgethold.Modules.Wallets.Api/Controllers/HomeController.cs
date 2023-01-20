using Microsoft.AspNetCore.Mvc;

namespace Budgethold.Modules.Wallets.Api.Controllers;

[Route("wallets-module")]
internal class HomeController : ControllerBase
{
    [HttpGet] 
    public ActionResult<string> Get() => "Wallets API";
}