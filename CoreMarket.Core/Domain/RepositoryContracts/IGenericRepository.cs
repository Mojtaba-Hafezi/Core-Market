namespace CoreMarket.Core.Domain.RepositoryContracts;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<int?> AddAsync(TEntity entity);

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity?> GetByIdAsync(int id);

    Task<bool> UpdateAsync(TEntity entity);

    Task<bool> DeleteAsync(int id);
}
