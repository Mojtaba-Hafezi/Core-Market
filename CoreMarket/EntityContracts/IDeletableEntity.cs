namespace CoreMarket.EntitiesContracts;

public interface IDeletableEntity
{
    public int? DeletedByUserId { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; }
}
