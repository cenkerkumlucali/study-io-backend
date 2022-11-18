using Application.Repositories.Services.Feeds;
using Domain.Entities.Feeds;
using Persistence.Contexts;

namespace Persistence.Repositories.Feeds;

public class PostLikeRepository:EfRepositoryBase<PostLike,BaseDbContext>,IPostLikeRepository
{
    public PostLikeRepository(BaseDbContext context) : base(context)
    {
    }
}