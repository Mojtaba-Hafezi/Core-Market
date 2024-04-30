using Application.DTOs;
using Application.Helpers;
using Application.ServiceContracts;
using Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IValidator<ProductDTO>, ProductDTOValidationHelper>();
        }
    }
}
