using CoreMarket.Core.Domain.Entities;

namespace CoreMarket.Core.Domain.RepositoryContracts;

public interface ICategoryRepository
{
    void AddCategory(Category category);

    List<Category> GetCategories();

    Category? GetCategoryById(int categoryId);

    void UpdateCategory(Category category);

    void DeleteCategory(int categoryId);
}
