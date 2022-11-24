using Domain.Entities;

namespace Application.Abstractions.Services;

public interface IFollowService
{
    Task<Follow> FindByMemberIdAndFollowMemberId(int memberId, int followMemberId);
    Task<bool> DeleteAsync(Follow follow);
}