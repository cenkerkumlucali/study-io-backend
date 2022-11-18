using Domain.Entities.Feeds;

namespace Application.Repositories.Services.Feeds;

public interface IPostImageRepository:IAsyncRepository<PostImageFile>,IRepository<PostImageFile>
{
    
}