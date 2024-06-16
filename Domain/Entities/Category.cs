using Domain.Entities.EntityContracts;

namespace Domain.Entities;

public class Category : BaseEntity
{
    public string Description { get; set; } = string.Empty;

    public List<Brand> brands { get; set; } = new List<Brand>();
}
