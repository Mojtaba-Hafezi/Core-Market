using CoreMarket.Data;
using CoreMarket.Interfaces;
using CoreMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreMarket.Services;

public class BrandService : IBrandService
{
    private readonly AppDbContext _appDbContext;

    public BrandService(AppDbContext appDbContext) => _appDbContext = appDbContext;

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
