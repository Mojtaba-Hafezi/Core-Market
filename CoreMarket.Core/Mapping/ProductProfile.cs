using AutoMapper;
using CoreMarket.Core.Domain.Entities;
using CoreMarket.Core.DTO;

namespace CoreMarket.Core.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDTO, Product>();
        CreateMap<Product, ProductDTO>();
    }
}
