using Application.Abstractions.Services;
using Application.Features.Follows.Dtos;
using Application.Repositories.Services.Follows;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services;

public class FollowManager : IFollowService
{
    private IFollowRepository _followRepository;

    public FollowManager(IFollowRepository followRepository)
    {
        _followRepository = followRepository;
    }

    public async Task<Follow> FindByMemberIdAndFollowMemberId(int memberId, int followMemberId)
    {
        Follow? follow =
            await _followRepository.GetAsync(c => c.FollowerId == memberId && c.FollowingId == followMemberId);
        return follow;
    }

    public async Task<Follow> DeleteAsync(Follow follow)
    {
        var findFollow = await FindByMemberIdAndFollowMemberId(follow.FollowerId, follow.FollowingId);
        if (findFollow is null)
            return null;
        return await _followRepository.DeleteAsync(findFollow);
    }

    public async Task<Follow> DeleteFollowerAsync(Follow follow)
    {
        var findFollow = await FindByMemberIdAndFollowMemberId(follow.FollowerId, follow.FollowingId);
        if (findFollow is null)
            return null;
        return await _followRepository.DeleteAsync(findFollow);
    }

    public async Task<FollowerDto> GetFollowers(int memberId)
    {
        List<Follow> following = await _followRepository.GetAllAsync(c => c.FollowingId == memberId,
            include: c => c.Include(c => c.Follower).Include(c => c.Following));
        List<Follow> follower = await _followRepository.GetAllAsync(c => c.FollowerId == memberId);

        var data = from f in following
            
            join ff in follower on f.FollowerId equals ff.FollowingId into co
            from _co in co.DefaultIfEmpty()
            select new
            {
                UserId = f.FollowerId,
                UserName = f.Follower.UserName,
                FullName = f.Follower.FirstName + " " + f.Follower.LastName,
                PictureUrl = f.Follower.UserImageFiles?.Select(c => c?.Url),
                IsFollowing = _co != null ? true : false
            };
        return new FollowerDto
        {
            Detail = data.Select(c => new
            {
                UserId = c.UserId,
                UserName = c.UserName,
                FullName = c.FullName,
                PictureUrl = c.PictureUrl,
                IsFollowing = c.IsFollowing
            }).ToList(),
        };
    }
}