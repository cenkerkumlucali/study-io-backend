using Application.Services.Repositories.Feeds;
using Core.Persistence.Repositories;
using Domain.Entities.Feeds;
using Persistence.Contexts;

namespace Persistence.Repositories.Feeds;

public class PostRepository:EfRepositoryBase<Post,BaseDbContext>,IPostRepository
{
    public PostRepository(BaseDbContext context) : base(context)
    {
    }
}