using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDTO, DigitalProduct>();
        CreateMap<DigitalProduct, ProductDTO>();

        CreateMap<ProductDTO, PhysicalProduct>();
        CreateMap<PhysicalProduct, ProductDTO>();

        CreateMap<ProductDTO, BaseProduct>()
            .Include<ProductDTO,DigitalProduct>()
            .Include<ProductDTO,PhysicalProduct>();

        CreateMap<BaseProduct, ProductDTO>()
            .Include<DigitalProduct,ProductDTO>()
            .Include<PhysicalProduct,ProductDTO>();

    }
}
