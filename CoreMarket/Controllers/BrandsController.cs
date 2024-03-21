using CoreMarket.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CoreMarket.Models;
using CoreMarket.Services;
namespace CoreMarket.Controllers;

public class BrandsController : Controller
{
    private readonly IBrandService _brandService;
    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    public IActionResult Index()
    {
        List<Brand> brandsList = _brandService.GetBrands();
        return Ok(brandsList);
    }

    [HttpPost]
    public IActionResult Add(Brand brand)
    {
        _brandService.AddBrand(brand);
        return Ok();
    }
}
