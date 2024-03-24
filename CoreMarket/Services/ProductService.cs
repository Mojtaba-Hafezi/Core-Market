using CoreMarket.Data;
using CoreMarket.Models;
using CoreMarket.ServiceContracts;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;

namespace CoreMarket.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _appDbContext;
    public ProductService(AppDbContext appDbContext) => _appDbContext = appDbContext;


    public async Task<bool> AddProduct(ProductDTO productDTO)
    {
        Product product = new Product
        {
            BrandId = productDTO.BrandId,
            Name = productDTO.Name,
            Price = productDTO.Price,
            Quantity = productDTO.Quantity
        };
        await _appDbContext.Products.AddAsync(product);
        return (await _appDbContext.SaveChangesAsync() > 0);
    }

    public async Task<List<ProductDTO>> GetProducts()
    {
        List<Product> products = await _appDbContext.Products.ToListAsync();
        List<ProductDTO> productsDTO = new List<ProductDTO>();

        foreach (Product product in products)
        {
            ProductDTO productDTO = new ProductDTO();
            productDTO.BrandId = product.BrandId;
            productDTO.Name = product.Name;
            productDTO.Price = product.Price;
            productDTO.Quantity = product.Quantity;
            productsDTO.Add(productDTO);
        }

        return productsDTO;
    }


    public async Task<ProductDTO?> GetProductById(int productId)
    {
        Product? product = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
        if(product == null)
        {
            return null;
        }
        ProductDTO productDTO = new ProductDTO
        {
            Name = product.Name,
            BrandId = product.BrandId,
            Price = product.Price,
            Quantity = product.Quantity
        };
        return productDTO;
    }

    public async Task<bool> DeleteProduct(int productDTOId)
    {
        var productToRemove = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == productDTOId);

        if (productToRemove != null)
        {
            _appDbContext.Products.Remove(productToRemove);
        }
        return (await _appDbContext.SaveChangesAsync() > 0);
    }

    public async Task<bool> UpdateProduct(ProductDTO productDTO, int id)
    {
        var productToUpdate = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (productToUpdate != null)
        {
            productToUpdate.Name = productDTO.Name;
            productToUpdate.Price = productDTO.Price;
            productToUpdate.Quantity = productDTO.Quantity;
            productToUpdate.BrandId = productDTO.BrandId;
        }
        return (await _appDbContext.SaveChangesAsync() > 0);
    }

}
