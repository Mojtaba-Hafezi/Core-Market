using Microsoft.AspNetCore.Mvc;
using CoreMarket.Core.Domain.RepositoryContracts;
using CoreMarket.Core.Domain.Entities;
namespace CoreMarket.UI.Controllers;

public class BrandsController : Controller
{
    private readonly IBrandRepository _brandRepository;
    public BrandsController(IBrandRepository brandRepository) => _brandRepository = brandRepository;


    public IActionResult GetAll()
    {
        List<Brand> brandsList = _brandRepository.GetBrands();
        return Ok(brandsList);
    }

    [HttpPost]
    public IActionResult Add(Brand brand)
    {
        _brandRepository.AddBrand(brand);
        return Ok();
    }
}
