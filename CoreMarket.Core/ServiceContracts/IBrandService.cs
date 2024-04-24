using CoreMarket.Core.Domain.Entities;

namespace CoreMarket.Core.ServiceContracts;

public interface IBrandService
{
    Task<Brand?> GetByIdAsync(int id);
}
