using Microsoft.AspNetCore.Mvc;

namespace CoreMarket.UI.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return Ok();
    }
}
