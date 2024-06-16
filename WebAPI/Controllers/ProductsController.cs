﻿using Application.DTOs;
using Application.ServiceContracts;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
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
    [ProducesResponseType(typeof(PagedProductDTO), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> GetAll(int page, int limit, string? term)
    {
        PagedEntityDTO<BaseProduct> pagedProducts = await _productsService.GetAllAsync(page, limit, term);
        PagedProductDTO pagedProductDTO =
        new PagedProductDTO
        {
            PagedEntities = [.. pagedProducts.PagedEntities],
            TotalCount = pagedProducts.TotalCount,
            TotalPages = pagedProducts.TotalPages
        };
        return Ok(pagedProductDTO);
    }


    [HttpGet]
    [Route("{id:int}", Name = "GetById")]
    [ProducesResponseType(typeof(BaseProduct), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("The id should be an integer greater than zero");

        BaseProduct? product = await _productsService.GetByIdAsync(id);

        if (product is null)
            return NotFound($"The product with id={id} was not found");

        return Ok(product);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> Add([FromBody] ProductDTO productDTO)
    {
        bool isDigitalProduct = productDTO.FileSize is not null;
        bool isPhysicalProduct = productDTO.Weight is not null || productDTO.Quantity is not null;
        if (isDigitalProduct && isPhysicalProduct)
            return BadRequest("Product should be either Physical or Digital!");

        Brand? brand = await _brandService.GetByIdAsync(productDTO.BrandId);

        if (brand is null)
            return NotFound($"The brand was not found for id = {productDTO.BrandId}");

        BaseProduct product;
        if (isDigitalProduct)
        {
            product = _mapper.Map<DigitalProduct>(productDTO);
        }
        else
        {
            product = _mapper.Map<PhysicalProduct>(productDTO);
        }
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

    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (id <= 0)
            return BadRequest("The id should be an integer greater than zero");

        BaseProduct? product = await _productsService.GetByIdAsync(id);

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

    public async Task<IActionResult> Update([FromBody] ProductDTO productDTO, [FromRoute] int id)
    {
        bool isDigitalProduct = productDTO.FileSize is not null;
        bool isPhysicalProduct = productDTO.Weight is not null || productDTO.Quantity is not null;

        if (id <= 0)
            return BadRequest("The id should be an integer greater than zero");

        if (isDigitalProduct && isPhysicalProduct)
            return BadRequest("Product should be either Physical or Digital!");

        BaseProduct? productToUpdate = await _productsService.GetByIdAsync(id);

        if (productToUpdate is null)
            return NotFound($"The product with id={id} was not found");

        if (productToUpdate.IsDeleted)
            return StatusCode(410, $"The product with id={id} has beed deleted");

        BaseProduct newProduct;
        if (isDigitalProduct)
        {
            newProduct = _mapper.Map<DigitalProduct>(productDTO);
        }
        else
        {
            newProduct = _mapper.Map<PhysicalProduct>(productDTO);
        }
        newProduct.Id = id;
        if (newProduct.GetType() != productToUpdate.GetType())
            return BadRequest("The type of the product cannot be changed");

        if (await _productsService.UpdateAsync(newProduct))
            return Ok();

        return StatusCode(500, "An error occured! The product couldn't be updated in database");
    }

    [HttpGet("GetDeletedProductCount")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetDeletedProductCount()
    {
        int deletedProductsCount = await _productsService.DeletedProductCount();
        return Ok($"There are {deletedProductsCount} product(s) That are deleted!");
    }
}
