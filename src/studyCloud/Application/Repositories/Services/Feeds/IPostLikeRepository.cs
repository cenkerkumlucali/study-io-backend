using Domain.Entities.Feeds;

namespace Application.Repositories.Services.Feeds;

public interface IPostLikeRepository:IAsyncRepository<PostLike>,IRepository<PostLike>
{
    
}