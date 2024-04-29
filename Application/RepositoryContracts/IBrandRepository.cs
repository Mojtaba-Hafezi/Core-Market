using Domain.Entities;

namespace Application.RepositoryContracts;

public interface IBrandRepository
{
    void AddBrand(Brand brand);

    List<Brand> GetBrands();

    Task<Brand?> GetBrandById(int brandId);

    void UpdateBrand(Brand brand);

    void DeleteBrand(int brandId);
}
