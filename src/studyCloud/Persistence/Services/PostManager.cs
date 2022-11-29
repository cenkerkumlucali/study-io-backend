using Application.Abstractions.Services;
using Application.Features.Feeds.Post.Dtos;
using Application.Repositories.Services.Feeds;
using Domain.Entities;
using Domain.Entities.Feeds;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services;

public class PostManager : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IFollowService _followService;
    private readonly IPostImageFileService _postImageFileService;
    private readonly IMentionService _mentionService;
    private readonly IUserService _userService;

    public PostManager(IPostRepository postRepository, IFollowService followService, IPostImageFileService postImageFileService, IMentionService mentionService, IUserService userService)
    {
        _postRepository = postRepository;
        _followService = followService;
        _postImageFileService = postImageFileService;
        _mentionService = mentionService;
        _userService = userService;
    }

    public async Task<PostUploadDto> Upload(PostUploadDto postUploadDto)
    {
        User user = await _userService.GetById(postUploadDto.Post.UserId);
        Post createdPost = await _postRepository.AddAsync(postUploadDto.Post);
        await _postImageFileService.Upload(createdPost.Id, postUploadDto.Files);
        await _mentionService.MentionMembers(user,createdPost);
        return new PostUploadDto
        {
            Post = createdPost,
            Files = postUploadDto.Files
        };
    }

    public async Task<List<object>> GetPostPageOfFollowingMembersByUserId(int userId, int page, int size)
    {
        List<Follow> following = await _followService.GetFollowings(userId);

        var data = from post in _postRepository.GetList(include: c => c.Include(c => c.PostImageFiles)
                .Include(c => c.Comments)
                .Include(c => c.PostLikes)).Items
            join follow in following on post.UserId equals follow.FollowingId
            select new
            {
                PostId = post.Id,
                UserName = follow.Following.UserName,
                PictureUrl = follow.Following.UserImageFiles?.FirstOrDefault()?.Url,
                FullName = follow.Following.FirstName + " " + follow.Following.LastName,
                Content = post.Content,
                FilePath = post.PostImageFiles.Select(c => c.Url),
                CommentCount = post.Comments.Count,
                PostLike = post.PostLikes.Count,
                CreatedDate = post.CreatedDate
            };
        data = data.Skip(page * size).Take(size).ToList();
        return new List<object> { data };
    }
}