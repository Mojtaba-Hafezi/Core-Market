using CoreMarket.Models;
using CoreMarket.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace CoreMarket.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productsService;
    public ProductsController(IProductService productService) => _productsService = productService;

    //آیا نیاز به تعریف روت برای اکشن متدها هست؟
    //[Route("/GetAll")]
    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _productsService.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Product? product = _productsService.GetProductById(id);
        return Ok(product);
    }

    [HttpPost]
    public IActionResult Add(Product product)
    {
        _productsService.AddProduct(product);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _productsService.DeleteProduct(id);
        return Ok();
    }


    [HttpPut]
    public IActionResult Update(Product product)
    {
        _productsService.UpdateProduct(product);
        return Ok();
    }
}
