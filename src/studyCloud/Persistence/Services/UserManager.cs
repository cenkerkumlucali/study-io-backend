using Application.Abstractions.Services;
using Application.Features.Post.Dtos;
using Application.Features.Users.User.Dtos;
using Application.Repositories.Services.Feeds;
using Application.Repositories.Services.Follows;
using Application.Repositories.Services.Users;
using Application.Security.Hashing;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IFollowRepository _followRepository;
    private readonly IBlockRepository _blockRepository;
    private readonly IPostRepository _postRepository;

    public UserManager(IUserRepository userRepository, IFollowRepository followRepository,
        IBlockRepository blockRepository, IPostRepository postRepository)
    {
        _userRepository = userRepository;
        _followRepository = followRepository;
        _blockRepository = blockRepository;
        _postRepository = postRepository;
    }

    public async Task<User> AddAsync(User user)
    {
        User createdUser = await _userRepository.AddAsync(user);
        return createdUser;
    }

    public async Task<User?> GetByEmail(string email)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == email);
        return user;
    }

    public async Task<User> GetById(long id)
    {
        User? user = await _userRepository.GetAsync(u => u.Id == id,
            include: c => c.Include(c => c.UserImageFiles)
                .Include(c => c.UserOperationClaims));
        return user;
    }

    public async Task<IList<User>> GetAllByUsernameIn(ICollection<string> userNames)
    {
        IList<User> users = (await _userRepository.GetListAsync(c => userNames.Contains(c.UserName))).Items;
        return users;
    }

    public async Task<IList<User>> GetAllByIdIn(ICollection<long> ids)
    {
        IList<User> users = (await _userRepository.GetListAsync(c => ids.Contains(c.Id),include:c=>c.Include(c=>c.UserImageFiles))).Items;
        return users;
    }

    public async Task<User> Update(User user)
    {
        User updatedUser = await _userRepository.UpdateAsync(user);
        return updatedUser;
    }

    public async Task<User> GetByUserName(string userName)
    {
        User user = await _userRepository.GetAsync(c => c.UserName == userName,
            include: c => c.Include(c => c.UserImageFiles)
                .Include(c => c.UserOperationClaims));
        return user;
    }

    public async Task<ProfileDto> GetUserProfile(long targetId, long memberId)
    {
        User targetUser = await GetById(targetId);
        return await GetUserProfileByLoginMemberIdAndTargetId(memberId, targetUser.Id);
    }

    public async Task<ProfileDto> GetUserProfileByLoginMemberIdAndTargetId(long loginUserId, long targetId)
    {
        var user = await GetById(targetId);
        return new ProfileDto
        {
            UserName = user.UserName,
            FullName = user.FirstName + " " + user.LastName,
            Introduce = user.Introduce,
            PictureUrl = user.UserImageFiles.FirstOrDefault()?.Url,
            IsFollowing = await isFollowing(loginUserId, user.Id),
            IsFollower = await isFollower(loginUserId, user.Id),
            IsBlocking = await isBlocking(loginUserId, user.Id),
            IsBlocked = await isBlocked(loginUserId, user.Id),
            PostsCount = await getPostCount(user.Id),
            FollowersCount = await getFollowerCount(user.Id),
            FollowingsCount = await getFollowingCount(user.Id),
            Posts = await getPosts(user.Id),
            IsMe = loginUserId == targetId
        };
    }

    public async Task<bool> ResetPassword(User user, string password, string confirmPassword)
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
        user = new User
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            UserName = user.UserName,
            Gender = user.Gender,
            Introduce = user.Introduce,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = user.Status
        };
        await _userRepository.UpdateAsync(user);
        return true;
    }

    private async Task<IList<PostListDto>> getPosts(long targetId)
    {
        IList<PostListDto> posts = (await _postRepository.GetListAsync(c => c.UserId == targetId,
                include: c => c.Include(c => c.User)
                    .ThenInclude(c => c.UserImageFiles)
                    .Include(c => c.Comments)
                    .Include(c=>c.PostLikes)))
            .Items.Select(c => new PostListDto()
            {
                Id = c.Id,
                FullName = c.User.FirstName + " " + c.User.LastName,
                Content = c.Content,
                FilesUrl = c.User.UserImageFiles?.Select(c => c.Url).ToList(),
                LikePostCount = c.PostLikes.Count,
                CommentCount = c.Comments.Count,
                CreatedDate = c.CreatedDate
            }).ToList();
        ;
        return posts;
    }

    private async Task<int> getPostCount(long targetId)
    {
        return (await _postRepository.GetListAsync(c => c.UserId == targetId)).Count;
    }

    private async Task<int> getFollowingCount(long targetId)
    {
        return (await _followRepository.GetListAsync(c => c.FollowerId == targetId)).Count;
    }

    private async Task<int> getFollowerCount(long targetId)
    {
        return (await _followRepository.GetListAsync(c => c.FollowingId == targetId)).Count;
    }

    private async Task<bool> isFollowing(long loginUserId, long targetId)
    {
        return (await _followRepository.GetListAsync(c => c.FollowerId == loginUserId && c.FollowingId == targetId))
            .Items.Any();
    }

    private async Task<bool> isFollower(long loginUserId, long targetId)
    {
        return (await _followRepository.GetListAsync(c => c.FollowerId == targetId && c.FollowingId == loginUserId))
            .Items.Any();
    }

    private async Task<bool> isBlocking(long loginUserId, long targetId)
    {
        return (await _blockRepository.GetListAsync(c => c.AgentId == loginUserId && c.TargetId == targetId)).Items
            .Any();
    }

    private async Task<bool> isBlocked(long loginUserId, long targetId)
    {
        return (await _blockRepository.GetListAsync(c => c.AgentId == targetId && c.TargetId == loginUserId)).Items
            .Any();
    }
}