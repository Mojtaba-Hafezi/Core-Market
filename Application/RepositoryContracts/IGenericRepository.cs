using Application.DTOs;

namespace Application.RepositoryContracts;


public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<int?> AddAsync(TEntity entity);

    Task<PagedEntityDTO<TEntity>> GetAllAsync(int page, int limit, string? term);

    Task<TEntity?> GetByIdAsync(int id);

    Task<bool> UpdateAsync(TEntity entity);

    Task<bool> DeleteAsync(int id);
}
