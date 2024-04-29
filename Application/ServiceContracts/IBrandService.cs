using Domain.Entities;

namespace Application.ServiceContracts;

public interface IBrandService
{
    Task<Brand?> GetByIdAsync(int id);
}
