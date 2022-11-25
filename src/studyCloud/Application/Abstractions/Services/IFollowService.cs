using Application.Features.Follows.Dtos;
using Domain.Entities;

namespace Application.Abstractions.Services;

public interface IFollowService
{
    Task<Follow> FindByMemberIdAndFollowMemberId(int memberId, int followMemberId);
    Task<Follow> DeleteAsync(Follow follow);
    Task<Follow> DeleteFollowerAsync(Follow follow);
    Task<FollowerDto> GetFollowers(int memberId);

}