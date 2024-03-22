using CoreMarket.Interfaces;
using CoreMarket.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreMarket.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;
    public CategoriesController(ICategoryService categoryService) => _categoryService = categoryService;
    

    [HttpGet]
    public IActionResult GetAll()
    {
        var categories = _categoryService.GetCategories();
        return Ok(categories);
    }

    [HttpPost]
    public IActionResult Add(Category category )
    {
        _categoryService.AddCategory(category);
        return Ok();
    }
}
