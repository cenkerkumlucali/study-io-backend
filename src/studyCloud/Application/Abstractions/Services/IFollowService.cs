using Application.Features.Follows.Dtos;
using Domain.Entities;

namespace Application.Abstractions.Services;

public interface IFollowService
{
    Task<Follow> FindByMemberIdAndFollowMemberId(long memberId, long followMemberId);
    Task<Follow> DeleteAsync(Follow follow);
    Task<Follow> DeleteFollowerAsync(Follow follow);
    Task<FollowerDto> GetFollowers(long memberId);
    Task<List<Follow>> GetFollowings(long memberId);
}