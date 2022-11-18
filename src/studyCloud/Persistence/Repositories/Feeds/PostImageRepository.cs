using Application.Repositories.Services.Feeds;
using Domain.Entities.Feeds;
using Persistence.Contexts;

namespace Persistence.Repositories.Feeds;

public class PostImageRepository:EfRepositoryBase<PostImageFile,BaseDbContext>,IPostImageRepository
{
    public PostImageRepository(BaseDbContext context) : base(context)
    {
    }
}