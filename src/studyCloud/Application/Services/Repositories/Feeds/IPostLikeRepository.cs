using Core.Persistence.Repositories;
using Domain.Entities.Feeds;

namespace Application.Services.Repositories.Feeds;

public interface IPostLikeRepository:IAsyncRepository<PostLike>,IRepository<PostLike>
{
    
}