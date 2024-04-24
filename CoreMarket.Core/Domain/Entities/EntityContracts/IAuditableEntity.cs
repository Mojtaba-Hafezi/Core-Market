namespace CoreMarket.Core.Domain.Entities.EntityContracts;

public interface IAuditableEntity
{
    public int? CreatedByUserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? ModifiedByUserId { get; set; }
    public DateTime? ModifiedAt { get; set; }
}
