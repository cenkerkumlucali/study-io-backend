using Application.Services.Repositories.Feeds;
using Core.Persistence.Repositories;
using Domain.Entities.Feeds;
using Persistence.Contexts;

namespace Persistence.Repositories.Feeds;

public class PostImageRepository:EfRepositoryBase<PostImage,BaseDbContext>,IPostImageRepository
{
    public PostImageRepository(BaseDbContext context) : base(context)
    {
    }
}