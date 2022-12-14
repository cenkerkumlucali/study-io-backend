using Domain.Entities.Common;

namespace Domain.Entities.Users;

public class UserOperationClaim : BaseEntity
{
    public long UserId { get; set; }
    public long OperationClaimId { get; set; }

    public virtual User User { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }
}