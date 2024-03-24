using CoreMarket.Models;

namespace CoreMarket.ServiceContracts;


public interface IProductService
{
    Task<bool> AddProduct(ProductDTO productDTO);

    Task<List<ProductDTO>> GetProducts();

    Task<ProductDTO?> GetProductById(int productId);

    Task<bool> UpdateProduct(ProductDTO productDTO, int id);

    Task<bool> DeleteProduct(int productDTOId);
}
