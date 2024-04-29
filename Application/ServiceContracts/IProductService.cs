using Domain.Entities;

namespace Application.ServiceContracts;

public interface IProductService
{
    Task<int?> AddAsync(Product product);

    Task<IEnumerable<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(int id);

    Task<bool> UpdateAsync(Product product);

    Task<bool> DeleteAsync(int id);
}
