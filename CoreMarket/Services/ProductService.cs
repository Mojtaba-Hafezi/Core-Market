using CoreMarket.Data;
using CoreMarket.Models;
using CoreMarket.ServiceContracts;

namespace CoreMarket.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _appDbContext;
    public ProductService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void AddProduct(Product product)
    {
        _appDbContext.Products.Add(product);
        _appDbContext.SaveChanges();
    }

    public List<Product> GetProducts()
    {
        return _appDbContext.Products.ToList();
    }

    public Product? GetProductById(int productId)
    {
        return _appDbContext.Products.Where(p => p.Id == productId).FirstOrDefault();
    }

    public void DeleteProduct(int productId)
    {
        var productToRemove = _appDbContext.Products.Where(p => p.Id == productId).FirstOrDefault();

        if (productToRemove != null)
        {
            _appDbContext.Products.Remove(productToRemove);
            _appDbContext.SaveChanges();
        }
    }

    public void UpdateProduct(Product product)
    {
        var productToUpdate = _appDbContext.Products.Where(p => p.Id == product.Id).FirstOrDefault();

        if (productToUpdate != null)
        {
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.Quantity = product.Quantity;
            productToUpdate.BrandId = product.BrandId;
            _appDbContext.SaveChanges();
        }
    }
}
