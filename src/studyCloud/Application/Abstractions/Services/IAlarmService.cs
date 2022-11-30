using Application.Features.Alarm.Dtos;
using Domain.Entities;
using Domain.Enums;

namespace Application.Abstractions.Services;

public interface IAlarmService
{
    Task<IList<AlarmDto>> GetAlarms(int userId, int page, int size);
    Task Alert(int agentId, int targetId, int followId);
    Task Alert(AlarmType alarmType, int agentId, int targetId, int postId);
    Task Alert(AlarmType type, int agentId, int targetId, int postId, int comment);
    Task AlertBatch(AlarmType type, int agentId, IList<int> targetIds, int postId);
    Task AlertBatch(AlarmType type, int agentId, IList<int> targetIds, int postId, int comment);
    Task DeletePost(AlarmType type, int agentId, int targetId, int postId);
    Task DeleteComment(AlarmType type, int agentId, int targetId, int commentId);
    Task DeleteFollow(AlarmType type, int agentId, int targetId, int followId);
    Task DeleteAll(int postId);
    Task DeleteAll(IList<int> comments);
    Task DeleteByTypeAndAgentAndTargetAndPost(AlarmType type, int agentId, int targetId, int postId);
    Task DeleteByTypeAndAgentAndTargetAndComment(AlarmType type, int agentId, int targetId, int commentId);
    Task DeleteByTypeAndAgentAndTargetAndFollow(AlarmType type, int agentId, int targetId, int followId);
    Task<IList<Alarm>> GetAllByCommentIn(IList<int> comments);
}