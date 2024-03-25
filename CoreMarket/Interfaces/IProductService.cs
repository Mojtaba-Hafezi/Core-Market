using CoreMarket.Models;

namespace CoreMarket.ServiceContracts;


public interface IProductService
{
    Task<int?> Add(ProductDTO productDTO);

    Task<ICollection<ProductDTO>> GetAll();

    Task<ProductDTO?> GetById(int productId);

    Task<bool> Update(ProductDTO productDTO, int id);

    Task<bool> Delete(int productDTOId);
}
