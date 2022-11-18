using Application.Repositories.Services.UserOperationClaim;
using Persistence.Contexts;

namespace Persistence.Repositories.UserOperationClaim;

public class UserOperationClaimRepository : EfRepositoryBase<Domain.Entities.Users.UserOperationClaim, BaseDbContext>,
    IUserOperationClaimRepository
{
    public UserOperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}