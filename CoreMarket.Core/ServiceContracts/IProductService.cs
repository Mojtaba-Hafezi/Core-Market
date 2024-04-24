using CoreMarket.Core.Domain.Entities;

namespace CoreMarket.Core.ServiceContracts;

public interface IProductService
{
    Task<int?> AddAsync(Product product);

    Task<IEnumerable<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(int id);

    Task<bool> UpdateAsync(Product product);

    Task<bool> DeleteAsync(int id);
}
