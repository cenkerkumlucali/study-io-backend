namespace Domain.Entities.Common;

public class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public virtual DateTime UpdatedDate { get; set; }

    public BaseEntity()
    {
    }

    public BaseEntity(int id) : this()
    {
        Id = id;
    }
}