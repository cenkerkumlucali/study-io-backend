using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Common;

namespace Domain.Entities.Users;

public class Block : BaseEntity
{
    public long AgentId { get; set; }
    public long TargetId { get; set; }
    public User Agent { get; set; }
    public User Target { get; set; }
    
    [NotMapped] public override DateTime? UpdatedDate { get; set; }
    
    
}