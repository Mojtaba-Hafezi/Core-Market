using CoreMarket.Data;
using CoreMarket.Interfaces;
using CoreMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreMarket.Services;

public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : BaseModel

{
    protected readonly AppDbContext _appDbContext;

    public GenericService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int?> AddAsync(TEntity entity)
    {
        await _appDbContext.Set<TEntity>().AddAsync(entity);

        return (await _appDbContext.SaveChangesAsync() > 0) ? entity.Id : null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entityToRemove = await _appDbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        if (entityToRemove is not null)
        {
            _appDbContext.Set<TEntity>().Remove(entityToRemove);
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
        }
        _appDbContext.Entry(entity).State = EntityState.Modified;
        return (await _appDbContext.SaveChangesAsync() > 0);
    }

}

