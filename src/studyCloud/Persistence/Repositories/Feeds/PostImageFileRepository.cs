using Application.Repositories.Services.Feeds;
using Domain.Entities.Feeds;
using Domain.Entities.ImageFile;
using Persistence.Contexts;

namespace Persistence.Repositories.Feeds;

public class PostImageFileRepository:EfRepositoryBase<PostImageFile,BaseDbContext>,IPostImageFileRepository
{
    public PostImageFileRepository(BaseDbContext context) : base(context)
    {
    }
}