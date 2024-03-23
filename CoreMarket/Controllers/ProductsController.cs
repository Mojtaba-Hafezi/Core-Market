using CoreMarket.Interfaces;
using CoreMarket.Models;
using CoreMarket.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoreMarket.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productsService;
    private readonly IBrandService _brandService;
    public ProductsController(IProductService productService, IBrandService brandService)
    {
        _productsService = productService;
        _brandService = brandService;
    }
    
    [Route("GetAll")]
    [HttpGet]
    public ActionResult<List<Product>> GetAll()
    {
        var products = _productsService.GetProducts();

        //Ok - 200 - Success
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        //BadRequest - 400 - Bad request - client error
        if(id <= 0)
        {
            return BadRequest("The id should be an integer greater than zero");
        }

        Product? product = _productsService.GetProductById(id);

        //NotFound - 404 - Not found - client error
        if(product == null)
        {
            return NotFound($"The product with id={id} was not found");
        }

        //Ok - 200 - Success
        return Ok(product);
    }

    [Route("/add")]
    [HttpPost]
    public ActionResult<bool> Add(Product product)
    {
        //BadRequest - 400 - Bad request - client error
        if (product.BrandId <= 0)
        {
            return BadRequest("The id of the brand of the product should be greater than zero");
        }

        Brand? brand = _brandService.GetBrandById(product.BrandId);
        //NotFound - 404 - Not found - client error
        if (brand == null)
        {
            return NotFound("The brand was not found whit this id");
        }
        _productsService.AddProduct(product);

        //Ok - 200 - Success
        return Ok(true);
    }

    [HttpDelete("{id}")]
    public ActionResult<bool> Delete(int id)
    {
        //BadRequest - 400 - Bad request - client error
        if (id <= 0)
        {
            return BadRequest("The id should be an integer greater than zero");
        }

        Product? product = _productsService.GetProductById(id);

        //NotFound - 404 - Not found - client error
        if (product == null)
        {
            return NotFound($"The product with id={id} was not found");
        }

        _productsService.DeleteProduct(id);

        //Ok - 200 - Success
        return Ok(true);
    }


    [HttpPut]
    public IActionResult Update(Product product)
    {
        //BadRequest - 400 - Bad request - client error
        if (product.Id <= 0)
        {
            return BadRequest("The id should be an integer greater than zero");
        }

        Product? productToUpdate = _productsService.GetProductById(product.Id);

        //NotFound - 404 - Not found - client error
        if (productToUpdate == null)
        {
            return NotFound($"The product with id={product.Id} was not found");
        }

        _productsService.UpdateProduct(product);

        //Ok - 200 - Success
        return Ok();
    }
}
