using CoreMarket.Core.Domain.Entities.EntityContracts;

namespace CoreMarket.Core.Domain.Entities;

public class Category:BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public List<Brand> brands { get; set; } = new List<Brand>();
}
