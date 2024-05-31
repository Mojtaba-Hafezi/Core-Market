using Domain.Entities.EntityContracts;

namespace Domain.Entities;

public class Brand : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public List<BaseProduct> BaseProducts { get; set; } = new List<BaseProduct>();
}
