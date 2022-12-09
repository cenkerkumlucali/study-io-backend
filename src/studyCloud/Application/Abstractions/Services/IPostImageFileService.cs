using Domain.Entities.Feeds;
using Domain.Entities.ImageFile;

namespace Application.Abstractions.Services;

public interface IPostImageFileService : IImageFileService<PostImageFile>
{
    Task DeleteAllInPost(Post post);
}