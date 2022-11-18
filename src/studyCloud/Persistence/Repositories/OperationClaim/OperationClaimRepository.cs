using Application.Repositories.Services.Mentions;
using Application.Repositories.Services.OperationClaim;
using Persistence.Contexts;

namespace Persistence.Repositories.OperationClaim;

public class OperationClaimRepository:EfRepositoryBase< Domain.Entities.Users.OperationClaim,BaseDbContext>,IOperationClaimRepository
{
    public OperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}