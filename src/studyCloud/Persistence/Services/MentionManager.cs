using System.Collections.Immutable;
using Application.Abstractions.Services;
using Application.Repositories.Services.Mentions;
using Domain.Entities;
using Domain.Entities.Feeds;
using Domain.Entities.Users;
using Domain.Enums;
using Persistence.Operations;

namespace Persistence.Services;

public class MentionManager : IMentionService
{
    private readonly IMentionRepository _mentionRepository;
    private readonly IUserService _userService;

    public MentionManager(IMentionRepository mentionRepository, IUserService userService)
    {
        _mentionRepository = mentionRepository;
        _userService = userService;
    }

    public async Task<List<Mention>> MentionMembers(User user, Post post)
    {
        ImmutableList<string> userNames = ImmutableList.Create(user.UserName);
        List<string> extactMentions = StringExtractUtil.ExtractMentionsWithExceptList(post.Content, userNames);
        IList<User> mentionedMembers = await _userService.GetAllByUsernameIn(extactMentions);
        foreach (var mentionedMember in mentionedMembers)
        {
            await AddPostMentions(user.Id, mentionedMember.Id, MentionType.POST, post.Id);
        }

        //TODO:Alarm
        return new List<Mention>();
    }

    private async Task AddPostMentions(int agentId, int targetId, MentionType mentionType, int postId)
    {
        await _mentionRepository.AddAsync(new()
        {
            AgentId = agentId,
            TargetId = targetId,
            MentionType = mentionType,
            PostId = postId
        });
    }
}