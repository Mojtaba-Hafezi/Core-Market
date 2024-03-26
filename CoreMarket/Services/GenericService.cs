using CoreMarket.Data;
using CoreMarket.Interfaces;
using CoreMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreMarket.Services;

public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : BaseModel

{ 
    private readonly AppDbContext _appDbContext;

    public GenericService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int?> Add(TEntity entity)
    {
        await _appDbContext.Set<TEntity>().AddAsync(entity);

        return (await _appDbContext.SaveChangesAsync() > 0) ? entity.Id : null;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToRemove = await _appDbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        if (entityToRemove != null)
        {
            _appDbContext.Set<TEntity>().Remove(entityToRemove);
        }
        return (await _appDbContext.SaveChangesAsync() > 0);
    }

    public async Task<ICollection<TEntity>> GetAll()
    {
        return await _appDbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetById(int id)
    {
        return await _appDbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<bool> Update(TEntity entity)
    {
        _appDbContext.Set<TEntity>().Update(entity);
        return (await _appDbContext.SaveChangesAsync() > 0);
    }

}

