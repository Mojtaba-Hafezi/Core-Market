
namespace Domain.Entities.EntityContracts;

public abstract class BaseEntity : IDeletableEntity, IAuditableEntity
{
    public int Id { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public int? ModifiedByUserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? CreatedByUserId { get; set; }
    public DateTime? DeletedAt { get; set; }
    public int? DeletedByUserId { get; set; }
    public bool IsDeleted
    {
        get
        {
            if (DeletedAt is not null && DeletedAt != DateTime.MinValue)
                return true;
            else
                return false;
        }
        set
        {

        }
    }
}
