using CoreMarket.Models;

namespace CoreMarket.Interfaces
{
    public interface ICategoryService
    {
        void AddCategory(Category category);

        List<Category> GetCategories();

        Category? GetCategoryById(int categoryId);

        void UpdateCategory(Category category);

        void DeleteCategory(int categoryId);
    }
}
