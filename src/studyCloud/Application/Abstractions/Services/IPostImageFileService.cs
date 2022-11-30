using Domain.Entities.Feeds;

namespace Application.Abstractions.Services;

public interface IPostImageFileService : IImageFileService<PostImageFile>
{
    Task DeleteAllInPost(Post post);
}