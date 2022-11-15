using BaseEntity = Domain.Entities.Common.BaseEntity;

namespace Domain.Entities.Users;

public class OperationClaim : BaseEntity
{
    public string Name { get; set; }

    public OperationClaim()
    {
    }

    public OperationClaim(int id, string name) : base(id)
    {
        Name = name;
    }
}