using Core.Persistence.Repositories;
using Domain.Entities.Feeds;

namespace Application.Services.Repositories.Feeds;

public interface IPostImageRepository:IAsyncRepository<PostImage>,IRepository<PostImage>
{
    
}