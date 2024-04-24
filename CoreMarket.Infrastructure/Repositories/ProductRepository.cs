using CoreMarket.Core.Domain.Entities;
using CoreMarket.Core.Domain.RepositoryContracts;
using CoreMarket.Infrastructure.Database;

namespace CoreMarket.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        
    }
}
