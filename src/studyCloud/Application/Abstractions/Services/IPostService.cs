using Application.Features.Feeds.Post.Dtos;
using Domain.Entities.Feeds;

namespace Application.Abstractions.Services;

public interface IPostService
{
    Task<PostUploadDto> Upload(PostUploadDto post);
    Task<List<object>> GetPostPageOfFollowingMembersByUserId(int userId, int page, int size);
}