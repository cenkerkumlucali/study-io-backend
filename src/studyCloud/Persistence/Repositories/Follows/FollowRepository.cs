using Application.Repositories.Services.Follows;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.Follows;

public class FollowRepository:EfRepositoryBase<Follow,BaseDbContext>,IFollowRepository
{
    public FollowRepository(BaseDbContext context) : base(context)
    {
    }
}