using Application.RepositoryContracts;
using Application.ServiceContracts;
using Domain.Entities;

namespace Application.Services;

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
