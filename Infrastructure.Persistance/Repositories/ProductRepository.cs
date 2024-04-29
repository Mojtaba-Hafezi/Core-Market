using Application.RepositoryContracts;
using Domain.Entities;
using Infrastructure.Persistance.Context;

namespace Infrastructure.Persistance.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        
    }
}
