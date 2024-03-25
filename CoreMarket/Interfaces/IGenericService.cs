using CoreMarket.Models;

namespace CoreMarket.Interfaces;

public interface IGenericService<TEntity> where TEntity : class
{
    Task<int?> Add(TEntity entity);

    Task<ICollection<TEntity>> GetAll();

    Task<TEntity?> GetById(int id);

    Task<bool> Update(TEntity entity);

    Task<bool> Delete(int id);
}
