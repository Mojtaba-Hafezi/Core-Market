using AutoMapper;
using API.DTOs;
using Domain.Entities;

namespace CoreMarket.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDTO, Product>();
        CreateMap<Product, ProductDTO>();
    }
}
