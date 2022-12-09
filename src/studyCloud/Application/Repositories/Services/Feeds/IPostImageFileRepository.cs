using Domain.Entities.Feeds;
using Domain.Entities.ImageFile;

namespace Application.Repositories.Services.Feeds;

public interface IPostImageFileRepository:IAsyncRepository<PostImageFile>,IRepository<PostImageFile>
{
    
}