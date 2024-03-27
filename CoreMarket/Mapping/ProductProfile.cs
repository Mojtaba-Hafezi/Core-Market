using AutoMapper;
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
