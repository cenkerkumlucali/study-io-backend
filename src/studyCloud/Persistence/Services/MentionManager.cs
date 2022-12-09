using System.Collections.Immutable;
using Application.Abstractions.Services;
using Application.Repositories.Services.Mentions;
using Domain.Entities;
using Domain.Entities.Comments;
using Domain.Entities.Feeds;
using Domain.Entities.Users;
using Domain.Enums;
using Persistence.Operations;

namespace Persistence.Services;

public class MentionManager : IMentionService
{
    private readonly IMentionRepository _mentionRepository;
    private readonly IUserService _userService;
    private readonly IAlarmService _alarmService;

    public MentionManager(IMentionRepository mentionRepository, IUserService userService, IAlarmService alarmService)
    {
        _mentionRepository = mentionRepository;
        _userService = userService;
        _alarmService = alarmService;
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

        await _alarmService.AlertBatch(AlarmType.MENTION_POST, user.Id, mentionedMembers.Select(c=>c.Id).ToList(), post.Id);
        return new List<Mention>();
    }

    public async Task<List<Mention>> MentionMembers(User user, Comment comment)
    {
        ImmutableList<string> userNames = ImmutableList.Create(user.UserName);
        List<string> extactMentions = StringExtractUtil.ExtractMentionsWithExceptList(comment.Content, userNames);
        IList<User> mentionedMembers = await _userService.GetAllByUsernameIn(extactMentions);
        foreach (var mentionedMember in mentionedMembers)
        {
            await AddPostMentions(user.Id, mentionedMember.Id, MentionType.POST, comment.Id);
        }

        await _alarmService.AlertBatch(AlarmType.MENTION_COMMENT, user.Id, mentionedMembers.Select(c=>c.Id).ToList(),comment.PostId ,comment.Id);
        return new List<Mention>();
    }

    public async Task<bool> DeleteAll(Post post)
    {
        IList<Mention> mentions = (await _mentionRepository.GetListAsync(c => c.PostId == post.Id)).Items;
        await _mentionRepository.DeleteRangeAsync(mentions);
        return true;
    }

    public async Task<bool> DeleteAll(List<long> comments)
    {
        IList<Mention> mentions = (await _mentionRepository.GetListAsync(c => comments.Contains(c.Id))).Items;
        await _mentionRepository.DeleteRangeAsync(mentions);
        return true;
    }

    private async Task AddPostMentions(long agentId, long targetId, MentionType mentionType, long postId)
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