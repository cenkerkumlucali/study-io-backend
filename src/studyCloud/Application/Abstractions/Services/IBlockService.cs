using Domain.Entities.Users;

namespace Application.Abstractions.Services;

public interface IBlockService
{
    Task<bool> Block(Block block);
    Task<bool> Unblock(Block block);
    Task<List<Block>> GetByUserId(long userId);
}