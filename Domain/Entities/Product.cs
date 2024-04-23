using Domain.Base;

namespace Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public double Price { get; set; }

    public int Quantity { get; set; }

    public int BrandId { get; set; }
    public Brand? Brand { get; set; }
}
