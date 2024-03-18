using CoreMarket.Models;
using CoreMarket.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace CoreMarket.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productsService;
        public ProductsController(IProductService productService)
        {
            _productsService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _productsService.GetProducts();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _productsService.AddProduct(product);
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _productsService.DeleteProduct(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            Product? product = _productsService.GetProductById(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            _productsService.UpdateProduct(product);
            return Ok();
        }
    }
}
