using Application.RepositoryContracts;
using Domain.Entities;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly AppDbContext _appDbContext;

    public BrandRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

    public void AddBrand(Brand brand)
    {
        _appDbContext.Brands.Add(brand);
        _appDbContext.SaveChanges();
    }

    public List<Brand> GetBrands() => _appDbContext.Brands.ToList();


    public async Task<Brand?> GetBrandById(int brandId) => await _appDbContext.Brands.FirstOrDefaultAsync(b => b.Id == brandId);


    public void DeleteBrand(int brandId)
    {
        Brand? brandToRemove = _appDbContext.Brands.Where(b => b.Id == brandId).FirstOrDefault();

        if (brandToRemove != null)
        {
            _appDbContext.Brands.Remove(brandToRemove);
            _appDbContext.SaveChanges();
        }
    }

    public void UpdateBrand(Brand brand)
    {
        var brandToUpdate = _appDbContext.Brands.Where(b => b.Id == brand.Id).FirstOrDefault();

        if (brandToUpdate != null)
        {
            brandToUpdate.Name = brand.Name;
            _appDbContext.SaveChanges();
        }
    }

}
