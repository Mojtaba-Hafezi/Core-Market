using Application.RepositoryContracts;
using Application.ServiceContracts;
using Domain.Entities;

namespace Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int?> AddAsync(BaseProduct product)
    {
        return await _productRepository.AddAsync(product);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _productRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<BaseProduct>> GetAllAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<BaseProduct?> GetByIdAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<bool> UpdateAsync(BaseProduct product)
    {
        return await _productRepository.UpdateAsync(product);
    }

    public Task<int> DeletedProductCount()
    {
        return _productRepository.GetDeletedProductCount();
    }
}
