using AutoMapper;
using CoreMarket.DTOs;
using CoreMarket.Models;

namespace CoreMarket.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDTO, Product>();
        CreateMap<Product, ProductDTO>();
    }
}
