using Application.Features.Feeds.Post.Dtos;
using Domain.Entities.Feeds;

namespace Application.Abstractions.Services;

public interface IPostService
{
    Task<PostUploadDto> Upload(PostUploadDto post);
    Task<Post> Delete(Post post);
    Task<List<object>> GetPostPageOfFollowingMembersByUserId(long userId, int page, int size);
}