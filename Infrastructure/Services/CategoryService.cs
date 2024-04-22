using CoreMarket.Data;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace CoreMarket.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _appDbContext;

    public CategoryService(AppDbContext appDbContext) => _appDbContext = appDbContext;

    public void AddCategory(Category category)
    {
        _appDbContext.Categories.Add(category);
        _appDbContext.SaveChanges();
    }

    public List<Category> GetCategories() => _appDbContext.Categories.ToList();


    public Category? GetCategoryById(int categoryId) => _appDbContext.Categories.Where(c => c.Id == categoryId).FirstOrDefault();


    public void DeleteCategory(int categoryId)
    {
        var categoryToRemove = _appDbContext.Categories.Where(c => c.Id == categoryId).FirstOrDefault();

        if (categoryToRemove != null)
        {
            _appDbContext.Categories.Remove(categoryToRemove);
            _appDbContext.SaveChanges();
        }
    }

    public void UpdateCategory(Category category)
    {
        var categoryToUpdate = _appDbContext.Categories.Where(c => c.Id == category.Id).FirstOrDefault();

        if (categoryToUpdate != null)
        {
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Description = category.Description;
            _appDbContext.SaveChanges();
        }
    }
}
