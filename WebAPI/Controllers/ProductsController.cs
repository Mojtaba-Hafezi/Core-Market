using Application.DTOs;
using Application.ServiceContracts;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productsService;
    private readonly IBrandService _brandService;
    private readonly IMapper _mapper;
    public ProductsController(IProductService productService, IBrandService brandService, IMapper mapper)
    {
        _productsService = productService;
        _brandService = brandService;
        _mapper = mapper;
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {

        List<Product> products = (List<Product>) await _productsService.GetAllAsync();
        return Ok(products);

    }


    [HttpGet]
    [Route("{id:int}", Name = "GetById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<ActionResult> GetById([FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("The id should be an integer greater than zero");

        Product? product = await _productsService.GetByIdAsync(id);

        if (product is null)
            return NotFound($"The product with id={id} was not found");

        return Ok(product);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<ActionResult> Add([FromBody] ProductDTO productDTO)
    {
        Brand? brand = await _brandService.GetByIdAsync(productDTO.BrandId);

        if (brand is null)
            return NotFound($"The brand was not found for id = {productDTO.BrandId}");


        Product product = _mapper.Map<Product>(productDTO);
        int? productId = await _productsService.AddAsync(product);

        //if (productId is not null)
        return CreatedAtRoute("GetById", new { id = productId }, productDTO);

        //return StatusCode(500, "An error occured! The product couldn't be added to the database");
    }



    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status410Gone)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("The id should be an integer greater than zero");

        Product? product = await _productsService.GetByIdAsync(id);

        if (product is null)
            return NotFound($"The product with id={id} was not found");

        if (product.IsDeleted)
            return StatusCode(410, $"The product with id={id} has beed deleted already");

        if (await _productsService.DeleteAsync(id))
        return Ok();

        return StatusCode(500, "An error occured! The product couldn't be deleted from database");
    }



    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status410Gone)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<ActionResult> Update([FromBody] ProductDTO productDTO, [FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("The id should be an integer greater than zero");

        Product? productToUpdate = await _productsService.GetByIdAsync(id);

        if (productToUpdate is null)
            return NotFound($"The product with id={id} was not found");

        if (productToUpdate.IsDeleted)
            return StatusCode(410, $"The product with id={id} has beed deleted");

        Product newProduct = _mapper.Map<Product>(productDTO);
        newProduct.Id = id;

        if (await _productsService.UpdateAsync(newProduct))
            return Ok();

        return StatusCode(500, "An error occured! The product couldn't be updated in database");
    }
}
