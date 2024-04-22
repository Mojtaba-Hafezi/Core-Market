using Domain.Entities;

namespace Domain.Interfaces;

public interface IBrandService
{
    void AddBrand(Brand brand);

    List<Brand> GetBrands();

    Task<Brand?> GetBrandById(int brandId);

    void UpdateBrand(Brand brand);

    void DeleteBrand(int brandId);
}
