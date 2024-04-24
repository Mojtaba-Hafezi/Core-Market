namespace CoreMarket.Core.Domain.Entities.EntityContracts;

public interface IDeletableEntity
{
    public int? DeletedByUserId { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; }
}
