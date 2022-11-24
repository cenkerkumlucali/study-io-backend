using Domain.Entities.Users;

namespace Application.Abstractions.Services;

public interface IBlockService
{
    Task<bool> Block(Block block);
    Task<bool> Unblock(Block block);
    Task<Block> FindByMemberIdAndBlockMemberId(int memberId, int blockMemberId);
}