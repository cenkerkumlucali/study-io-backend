using Domain.Entities.Feeds;

namespace Application.Repositories.Services.Feeds;

public interface IPostRepository:IAsyncRepository<Post>,IRepository<Post>
{
    
}