﻿using CoreMarket.Data;
using CoreMarket.Models;
using CoreMarket.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;

namespace CoreMarket.Services;

public class ProductService : GenericService<Product>, IProductService
{
    public ProductService(AppDbContext appDbContext) : base(appDbContext)
    {
        
    }
}
