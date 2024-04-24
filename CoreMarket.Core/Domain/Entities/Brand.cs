using CoreMarket.Core.Domain.Entities.EntityContracts;

namespace CoreMarket.Core.Domain.Entities;

public class Brand : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public List<Product> Products { get; set; } = new List<Product>();
}
