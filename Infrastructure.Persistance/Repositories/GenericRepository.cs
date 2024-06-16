using Application.DTOs;
using Application.RepositoryContracts;
using Domain.Entities;
using Domain.Entities.EntityContracts;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infrastructure.Persistance.Repositories;

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

    public async Task<PagedEntityDTO<TEntity>> GetAllAsync(int page, int limit, string? term)
    {
        List<TEntity> entities = new List<TEntity>();
        if (string.IsNullOrWhiteSpace(term))
        {
            entities = await _appDbContext.Set<TEntity>().ToListAsync();
        }
        else
        {
            entities = await _appDbContext.Set<TEntity>().Where(entity => entity.Name.ToLower().Contains(term)).ToListAsync();
        }
        int totalCount = entities.Count();
        int totalPages = Convert.ToInt32(Math.Ceiling((double)totalCount / limit));
        List<TEntity> PagedEntities = entities.Skip(limit * (page - 1)).Take(limit).ToList();

        PagedEntityDTO<TEntity> pagedEntityDTO =
            new PagedEntityDTO<TEntity>
            {
                PagedEntities = PagedEntities,
                TotalCount = totalCount,
                TotalPages = totalPages
            };
        return pagedEntityDTO;
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

