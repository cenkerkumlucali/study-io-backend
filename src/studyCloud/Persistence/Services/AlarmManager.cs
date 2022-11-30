using Application.Abstractions.Services;
using Application.Exceptions;
using Application.Features.Alarm.Dtos;
using Application.Repositories.Services.Alarm;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Persistence.Operations;

namespace Persistence.Services;

public class AlarmManager : IAlarmService
{
    private readonly IAlarmRepository _alarmRepository;


    public AlarmManager(IAlarmRepository alarmRepository)
    {
        _alarmRepository = alarmRepository;
    }

    public async Task<IList<AlarmDto>> GetAlarms(int userId, int page, int size)
    {
        IList<AlarmDto> alarmDto =
            (await _alarmRepository.GetListAsync(c => c.TargetId == userId, index: page, size: size,
                include: c =>
                    c.Include(c => c.Agent)
                        .ThenInclude(c => c.UserImageFiles)
                        .Include(c => c.Comment)
                        .ThenInclude(c => c.CommentImageFiles)
                        .Include(c => c.Post)
                        .ThenInclude(c => c.PostImageFiles), orderBy: c => c.OrderByDescending(c => c.CreatedDate)))
            .Items.Select(alarm => new AlarmDto()
            {
                Id = alarm.Id,
                Type = alarm.AlarmType.ToString(),
                Message = alarm.AlarmType == AlarmType.MENTION_POST
                    ? string.Format(Enumerations.GetEnumDescription(alarm.AlarmType), alarm.Agent.UserName,
                        alarm.Post.Content)
                    : alarm.AlarmType == AlarmType.MENTION_COMMENT
                      || alarm.AlarmType == AlarmType.COMMENT
                      || alarm.AlarmType == AlarmType.LIKE_COMMENT
                        ? string.Format(Enumerations.GetEnumDescription(alarm.AlarmType), alarm.Agent.UserName,
                            alarm.Comment.Content)
                        : alarm.AlarmType == AlarmType.FOLLOW || alarm.AlarmType == AlarmType.LIKE_POST
                            ? string.Format(Enumerations.GetEnumDescription(alarm.AlarmType), alarm.Agent.UserName)
                            : null,
                PictureUrl = alarm.Agent.UserImageFiles?.FirstOrDefault()?.Url,
                CreatedDate = alarm.CreatedDate
            }).ToList();
        alarmDto = alarmDto.Skip(page * size).Take(size).ToList();

        // List<int> agentIds = alarms.Where(c => c.AlarmType == AlarmType.FOLLOW).Select(c => c.AgentId).ToList();
        return alarmDto;
    }

    public async Task Alert(int agentId, int targetId, int followId)
    {
        await _alarmRepository.AddAsync(new Alarm
        {
            AgentId = agentId,
            TargetId = targetId,
            FollowId = followId,
            AlarmType = AlarmType.FOLLOW,
        });
    }

    public async Task Alert(AlarmType alarmType, int agentId, int targetId, int postId)
    {
        if (!alarmType.Equals(AlarmType.LIKE_POST))
        {
            throw new Exception(ErrorCode.MISMATCHED_ALARM_TYPE);
        }

        await _alarmRepository.AddAsync(new Alarm
        {
            AgentId = agentId,
            TargetId = targetId,
            PostId = postId,
            AlarmType = alarmType,
        });
    }

    public async Task Alert(AlarmType type, int agentId, int targetId, int postId, int commentId)
    {
        if (!type.Equals(AlarmType.COMMENT) && !type.Equals(AlarmType.LIKE_COMMENT) &&
            !type.Equals(AlarmType.MENTION_COMMENT))
        {
            throw new Exception(ErrorCode.MISMATCHED_ALARM_TYPE);
        }

        await _alarmRepository.AddAsync(new Alarm
        {
            AgentId = agentId,
            TargetId = targetId,
            PostId = postId,
            CommentId = commentId,
            AlarmType = type,
        });
    }

    public async Task AlertBatch(AlarmType type, int agentId, IList<int> targetIds, int postId)
    {
        if (!type.Equals(AlarmType.MENTION_POST))
        {
            throw new Exception(ErrorCode.MISMATCHED_ALARM_TYPE);
        }

        foreach (var targetId in targetIds) await AddMentionPostAlarms(agentId, targetId, postId);
    }

    public async Task AlertBatch(AlarmType type, int agentId, IList<int> targetIds, int postId, int commentId)
    {
        if (!type.Equals(AlarmType.MENTION_COMMENT))
        {
            throw new Exception(ErrorCode.MISMATCHED_ALARM_TYPE);
        }

        foreach (var targetId in targetIds) await AddMentionCommentAlarms(agentId, targetId, postId, commentId);
    }

    public async Task DeletePost(AlarmType type, int agentId, int targetId, int postId)
    {
        await DeleteByTypeAndAgentAndTargetAndPost(type, agentId, targetId, postId);
    }

    public async Task DeleteComment(AlarmType type, int agentId, int targetId, int commentId)
    {
        await DeleteByTypeAndAgentAndTargetAndComment(type, agentId, targetId, commentId);
    }

    public async Task DeleteFollow(AlarmType type, int agentId, int targetId, int followId)
    {
        await DeleteByTypeAndAgentAndTargetAndFollow(type, agentId, targetId, followId);
    }

    public async Task DeleteAll(int postId)
    {
        IList<Alarm> alarms = (await _alarmRepository.GetListAsync(c => c.PostId == postId)).Items;
        await _alarmRepository.DeleteRangeAsync(alarms);
    }

    public async Task DeleteAll(IList<int> commentIds)
    {
        var alarms = await GetAllByCommentIn(commentIds);
        await _alarmRepository.DeleteRangeAsync(alarms);
    }

    public async Task DeleteByTypeAndAgentAndTargetAndPost(AlarmType type, int agentId, int targetId, int postId)
    {
        Alarm? getPostAlarm = await _alarmRepository.GetAsync(c =>
            c.AlarmType == type && c.AgentId == agentId && c.TargetId == targetId && c.PostId == postId);
        if (getPostAlarm != null) await _alarmRepository.DeleteAsync(getPostAlarm);
    }

    public async Task DeleteByTypeAndAgentAndTargetAndComment(AlarmType type, int agentId, int targetId, int commentId)
    {
        Alarm? getCommentAlarm = await _alarmRepository.GetAsync(c =>
            c.AlarmType == type && c.AgentId == agentId && c.TargetId == targetId && c.CommentId == commentId);
        if (getCommentAlarm != null) await _alarmRepository.DeleteAsync(getCommentAlarm);
    }

    public async Task DeleteByTypeAndAgentAndTargetAndFollow(AlarmType type, int agentId, int targetId, int followId)
    {
        Alarm? getFollowAlarm = await _alarmRepository.GetAsync(c =>
            c.AlarmType == type && c.AgentId == agentId && c.TargetId == targetId && c.FollowId == followId);
        if (getFollowAlarm != null) await _alarmRepository.DeleteAsync(getFollowAlarm);
    }

    public async Task<IList<Alarm>> GetAllByCommentIn(IList<int> commentIds)
    {
        IList<Alarm> alarms =
            (await _alarmRepository.GetListAsync(c => commentIds.Contains((int)c.CommentId),
                include: c => c.Include(c => c.Comment))).Items;
        return alarms;
    }

    private async Task AddMentionPostAlarms(int agentId, int targetId, int postId)
    {
        await _alarmRepository.AddAsync(new Alarm
        {
            AgentId = agentId,
            TargetId = targetId,
            PostId = postId,
            AlarmType = AlarmType.MENTION_POST,
        });
    }

    private async Task AddMentionCommentAlarms(int agentId, int targetId, int postId, int commentId)
    {
        await _alarmRepository.AddAsync(new Alarm
        {
            AgentId = agentId,
            TargetId = targetId,
            PostId = postId,
            CommentId = commentId,
            AlarmType = AlarmType.MENTION_COMMENT,
        });
    }
}