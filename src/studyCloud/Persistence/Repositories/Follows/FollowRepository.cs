using Application.Services.Repositories.Follows;
using Domain.Entities.Follow;
using Persistence.Contexts;

namespace Persistence.Repositories.Follows;

public class FollowRepository:EfRepositoryBase<Follow,BaseDbContext>,IFollowRepository
{
    public FollowRepository(BaseDbContext context) : base(context)
    {
    }
}