using CoreMarket.Interfaces;
using CoreMarket.Models;
using CoreMarket.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

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


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<ActionResult<ICollection<Product>>> GetAll()
    {
        var products = await _productsService.GetAll();

        //Ok - 200 - Success
        return Ok(products);
    }



    [HttpGet]
    [Route("{id:int}", Name = "GetById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<ActionResult<Product>> GetById([FromRoute] int id)
    {
        //BadRequest - 400 - Bad request - client error
        if (id <= 0)
        {
            return BadRequest("The id should be an integer greater than zero");
        }

        ProductDTO? productDTO = await _productsService.GetById(id);

        //NotFound - 404 - Not found - client error
        if (productDTO == null)
        {
            return NotFound($"The product with id={id} was not found");
        }

        //Ok - 200 - Success
        return Ok(productDTO);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<ActionResult> Add([FromBody] ProductDTO productDTO)
    {
        //BadRequest - 400 - Bad request - client error
        if (productDTO.BrandId <= 0)
        {
            return BadRequest("The id of the brand of the product should be greater than zero");
        }

        Brand? brand = await _brandService.GetBrandById(productDTO.BrandId);
        //NotFound - 404 - Not found - client error
        if (brand == null)
        {
            return NotFound("The brand was not found whit this id");
        }

        //Created - 201 - Success
        int? productId = await _productsService.Add(productDTO);
        if (productId != null)
        {
            //Header:Location:http...../products/GetById/{id}
            return CreatedAtRoute("GetById", new { id = productId },productDTO);
        }

        //StatusCode - 500 - Internal server error
        return StatusCode(500, "An error occured! The product couldn't be added to the database");
    }



    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        //BadRequest - 400 - Bad request - client error
        if (id <= 0)
        {
            return BadRequest("The id should be an integer greater than zero");
        }

        ProductDTO? productDTO = await _productsService.GetById(id);

        //NotFound - 404 - Not found - client error
        if (productDTO == null)
        {
            return NotFound($"The product with id={id} was not found");
        }

        //Ok - 200 - Success
        if (await _productsService.Delete(id))
        {
            return Ok();
        }

        //StatusCode - 500 - Internal server error
        return StatusCode(500, "An error occured! The product couldn't be deleted from database");
    }



    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<ActionResult> Update([FromBody] ProductDTO productDTO, [FromRoute] int id)
    {
        //BadRequest - 400 - Bad request - client error
        if (id <= 0)
        {
            return BadRequest("The id should be an integer greater than zero");
        }

        ProductDTO? productToUpdate = await _productsService.GetById(id);

        //NotFound - 404 - Not found - client error
        if (productToUpdate == null)
        {
            return NotFound($"The product with id={id} was not found");
        }

        //Ok - 200 - Success
        if (await _productsService.Update(productDTO, id))
        {
            return Ok();
        }

        //StatusCode - 500 - Internal server error
        return StatusCode(500, "An error occured! The product couldn't be updated in database");
    }
}
