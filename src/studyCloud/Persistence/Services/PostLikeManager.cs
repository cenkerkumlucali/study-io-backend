using Application.Abstractions.Services;
using Application.Repositories.Services.Feeds;
using Domain.Entities.Feeds;

namespace Persistence.Services;

public class PostLikeManager:IPostLikeService
{
    private IPostLikeRepository _postLikeRepository;

    public PostLikeManager(IPostLikeRepository postLikeRepository)
    {
        _postLikeRepository = postLikeRepository;
    }

    public async Task DeleteAllInPost(Post post)
    {
        IList<PostLike> postLikes = (await _postLikeRepository.GetListAsync(c => c.PostId == post.Id)).Items;
        await _postLikeRepository.DeleteRangeAsync(postLikes);
    }
}