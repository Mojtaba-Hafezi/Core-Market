using CoreMarket.Core.Domain.Entities.EntityContracts;
using CoreMarket.Core.Domain.RepositoryContracts;
using CoreMarket.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CoreMarket.Infrastructure.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity

{
    protected readonly AppDbContext _appDbContext;

    public GenericRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int?> AddAsync(TEntity entity)
    {
        entity.CreatedAt = DateTime.Now;
        await _appDbContext.Set<TEntity>().AddAsync(entity);

        return (await _appDbContext.SaveChangesAsync() > 0) ? entity.Id : null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var originalEntity = await _appDbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);

        if (originalEntity is not null)
        {
            originalEntity.DeletedAt = DateTime.Now;
            _appDbContext.Set<TEntity>().Update(originalEntity);
        }

        return (await _appDbContext.SaveChangesAsync() > 0);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _appDbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _appDbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        var originalEntity = _appDbContext.Set<TEntity>().FirstOrDefault(e => e.Id == entity.Id);

        if (originalEntity is not null)
        {
            _appDbContext.Entry(originalEntity).State = EntityState.Detached;
            entity.CreatedAt = originalEntity.CreatedAt;
            entity.CreatedByUserId = originalEntity.CreatedByUserId;
            entity.ModifiedAt = DateTime.Now;
            _appDbContext.Entry(entity).State = EntityState.Modified;
        }

        return (await _appDbContext.SaveChangesAsync() > 0);
    }

}

