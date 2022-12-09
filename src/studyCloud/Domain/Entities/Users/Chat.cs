using Domain.Entities.Common;

namespace Domain.Entities.Users;

public class Chat : BaseEntity
{
    public string Message { get; set; }
    public string Type { get; set; }
    public long ToId { get; set; }
    public virtual User To { get; set; }
    public long FromId { get; set; }
    public virtual User From { get; set; }
    public DateTime? ReadAt { get; set; }
}