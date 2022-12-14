namespace Domain.Entities.Common;

public class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public virtual DateTime? UpdatedDate { get; set; }
}