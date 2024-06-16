using Application.DTOs;
using Domain.Entities;

namespace Application.ServiceContracts;

public interface IProductService
{
    Task<int?> AddAsync(BaseProduct product);

    Task<PagedEntityDTO<BaseProduct>> GetAllAsync(int page, int limit, string? term);

    Task<BaseProduct?> GetByIdAsync(int id);

    Task<bool> UpdateAsync(BaseProduct product);

    Task<bool> DeleteAsync(int id);

    Task<int> DeletedProductCount();
}
