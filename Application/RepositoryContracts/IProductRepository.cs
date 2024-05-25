using Domain.Entities;

namespace Application.RepositoryContracts;


public interface IProductRepository : IGenericRepository<Product>
{
    Task<int> HardDelete();
}
