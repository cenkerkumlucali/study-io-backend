using Application.Abstractions.Services;
using Application.Exceptions;
using Application.Repositories.Services.Users;
using Domain.Entities;
using Domain.Entities.Users;

namespace Persistence.Services;

public class BlockManager : IBlockService
{
    private readonly IBlockRepository _blockRepository;
    private readonly IUserService _userService;
    private readonly IFollowService _followService;

    public BlockManager(IBlockRepository blockRepository, IUserService userService, IFollowService followService)
    {
        _blockRepository = blockRepository;
        _userService = userService;
        _followService = followService;
    }

    public async Task<bool> Block(Block block)
    {
        User member = await _userService.GetById(block.AgentId);
        User blockMember = await _userService.GetById(block.TargetId);
        if (blockMember is null)
            throw new BusinessException(ErrorCode.MEMBER_NOT_FOUND);
        if (member.Id.Equals(blockMember.Id)) {
            throw new BusinessException(ErrorCode.BLOCK_MYSELF_FAIL);
        }

        Follow memberFollow = await _followService.FindByMemberIdAndFollowMemberId(member.Id, blockMember.Id);
        if (memberFollow is not null)
            await _followService.DeleteAsync(memberFollow);
        Follow blockMemberFollow = await _followService.FindByMemberIdAndFollowMemberId(blockMember.Id,member.Id);
        if (blockMemberFollow is not null)
            await _followService.DeleteAsync(blockMemberFollow);
        await _blockRepository.AddAsync(block);
        return true;
    }

    public async Task<bool> Unblock(Block block)
    {
        User member = await _userService.GetById(block.AgentId);
        User blockMember = await _userService.GetById(block.TargetId);
        if (blockMember is null)
            throw new BusinessException(ErrorCode.MEMBER_NOT_FOUND);
        if (member.Id.Equals(blockMember.Id)) {
            throw new BusinessException(ErrorCode.BLOCK_MYSELF_FAIL);
        }

        Block blockResult = await FindByMemberIdAndBlockMemberId(member.Id, blockMember.Id);
        await _blockRepository.DeleteAsync(blockResult);
        return true;
    }

    public async Task<Block> FindByMemberIdAndBlockMemberId(int memberId, int blockMemberId)
    {
        Block block = await _blockRepository.GetAsync(c => c.AgentId == memberId && c.TargetId == blockMemberId);
        return block;
    }
}