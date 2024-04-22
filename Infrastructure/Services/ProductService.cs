using CoreMarket.Data;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;

namespace CoreMarket.Services;

public class ProductService : GenericService<Product>, IProductService
{
    public ProductService(AppDbContext appDbContext) : base(appDbContext)
    {
        
    }
}
