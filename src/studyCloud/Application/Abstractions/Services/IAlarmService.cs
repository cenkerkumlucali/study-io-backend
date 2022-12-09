using Application.Features.Alarm.Dtos;
using Domain.Entities;
using Domain.Enums;

namespace Application.Abstractions.Services;

public interface IAlarmService
{
    Task<IList<AlarmDto>> GetAlarms(long userId, int page, int size);
    Task Alert(long agentId, long targetId, long followId);
    Task Alert(AlarmType alarmType, long agentId, long targetId, long postId);
    Task Alert(AlarmType type, long agentId, long targetId, long postId, long comment);
    Task AlertBatch(AlarmType type, long agentId, List<long> targetIds, long postId);
    Task AlertBatch(AlarmType type, long agentId, List<long> targetIds, long postId, long comment);
    Task DeletePost(AlarmType type, long agentId, long targetId, long postId);
    Task DeleteComment(AlarmType type, int agentId, int targetId, int commentId);
    Task DeleteFollow(AlarmType type, int agentId, int targetId, int followId);
    Task DeleteAll(long postId);
    Task DeleteAll(IList<int> comments);
    Task DeleteByTypeAndAgentAndTargetAndPost(AlarmType type, long agentId, long targetId, long postId);
    Task DeleteByTypeAndAgentAndTargetAndComment(AlarmType type, int agentId, int targetId, int commentId);
    Task DeleteByTypeAndAgentAndTargetAndFollow(AlarmType type, int agentId, int targetId, int followId);
    Task<IList<Alarm>> GetAllByCommentIn(IList<int> comments);
}