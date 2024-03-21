using Microsoft.AspNetCore.Mvc;

namespace CoreMarket.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return Ok();
    }
}
