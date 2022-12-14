using BaseEntity = Domain.Entities.Common.BaseEntity;

namespace Domain.Entities.Users;

public class OperationClaim : BaseEntity
{
    public string Name { get; set; }
}