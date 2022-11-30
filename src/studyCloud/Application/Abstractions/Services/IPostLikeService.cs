using Domain.Entities.Feeds;

namespace Application.Abstractions.Services;

public interface IPostLikeService
{
    Task DeleteAllInPost(Post post);
}