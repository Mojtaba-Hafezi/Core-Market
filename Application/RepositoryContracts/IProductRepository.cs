using Domain.Entities;

namespace Application.RepositoryContracts;


public interface IProductRepository : IGenericRepository<BaseProduct>
{
    Task<int> GetDeletedProductCount();
}
