using CoreMarket.Core.Domain.Entities;
using CoreMarket.Core.Domain.RepositoryContracts;
using CoreMarket.Core.ServiceContracts;

namespace CoreMarket.Core.Services;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;
    public BrandService(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }
    public Task<Brand?> GetByIdAsync(int id)
    {
        return _brandRepository.GetBrandById(id);
    }
}
