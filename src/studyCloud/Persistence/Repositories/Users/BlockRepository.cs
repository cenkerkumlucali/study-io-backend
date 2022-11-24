using Application.Repositories.Services.Users;
using Domain.Entities.Users;
using Persistence.Contexts;

namespace Persistence.Repositories.Users;

public class BlockRepository : EfRepositoryBase<Block, BaseDbContext>, IBlockRepository
{
    public BlockRepository(BaseDbContext context) : base(context)
    {
    }
}