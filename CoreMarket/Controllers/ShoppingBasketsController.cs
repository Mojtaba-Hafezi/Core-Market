using CoreMarket.Data;
using Microsoft.AspNetCore.Mvc;

namespace CoreMarket.Controllers
{
    public class ShoppingBasketsController : Controller
    {
        AppDbContext _appDbContext;
        public ShoppingBasketsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
