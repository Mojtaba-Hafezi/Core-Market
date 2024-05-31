using Domain.Entities.EntityContracts;

namespace Domain.Entities;

public class BaseProduct : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public double Price { get; set; }

    public int BrandId { get; set; }
    public Brand? Brand { get; set; }
}
