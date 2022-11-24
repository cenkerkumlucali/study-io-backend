using Application.Abstractions.Services;
using Application.Repositories.Services.Follows;
using Domain.Entities;

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

    public async Task<bool> DeleteAsync(Follow follow)
    {
        await _followRepository.DeleteAsync(follow);
        return true;
    }
}