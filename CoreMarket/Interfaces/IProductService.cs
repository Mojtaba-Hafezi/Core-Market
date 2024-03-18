using CoreMarket.Models;

namespace CoreMarket.ServiceContracts
 
{
    public interface IProductService
    {
        void AddProduct(Product product);

        List<Product> GetProducts();

        Product? GetProductById(int productId);

        void UpdateProduct(Product product);

        void DeleteProduct(int productId);
    }
}
