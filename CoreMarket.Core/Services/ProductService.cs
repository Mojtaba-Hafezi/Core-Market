using CoreMarket.Core.Domain.Entities;
using CoreMarket.Core.Domain.RepositoryContracts;
using CoreMarket.Core.ServiceContracts;

namespace CoreMarket.Core.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<int?> AddAsync(Product product)
    {
        return _productRepository.AddAsync(product);
    }

    public Task<bool> DeleteAsync(int id)
    {
        return _productRepository.DeleteAsync(id);
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        return _productRepository.GetAllAsync();
    }

    public Task<Product?> GetByIdAsync(int id)
    {
        return _productRepository.GetByIdAsync(id);
    }

    public Task<bool> UpdateAsync(Product product)
    {
        return _productRepository.UpdateAsync(product);
    }
}
