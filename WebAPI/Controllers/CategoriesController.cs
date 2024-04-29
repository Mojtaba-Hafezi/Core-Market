using Application.RepositoryContracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoriesController(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;
    

    [HttpGet]
    public IActionResult GetAll()
    {
        var categories = _categoryRepository.GetCategories();
        return Ok(categories);
    }

    [HttpPost]
    public IActionResult Add(Category category )
    {
        _categoryRepository.AddCategory(category);
        return Ok();
    }
}
