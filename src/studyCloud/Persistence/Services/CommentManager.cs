using Application.Abstractions.Services;
using Application.Repositories.Services.Comments;
using Domain.Entities.Comments;
using Domain.Entities.Feeds;
using Domain.Entities.Users;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services;

public class CommentManager : ICommentService
{
    private ICommentRepository _commentRepository;
    private readonly IMentionService _mentionService;
    private readonly IAlarmService _alarmService;
    private readonly IUserService _userService;

    public CommentManager(ICommentRepository commentRepository, IMentionService mentionService,
        IAlarmService alarmService, IUserService userService)
    {
        _commentRepository = commentRepository;
        _mentionService = mentionService;
        _alarmService = alarmService;
        _userService = userService;
    }

    public async Task<Comment?> GetById(int id)
    {
        return await _commentRepository.GetAsync(c => c.Id == id);
    }

    public async Task<Comment> Upload(Comment comment)
    {
        User user = await _userService.GetById(comment.UserId);
        Comment? createdComment = await _commentRepository.AddAsync(comment);
        Comment? getComment = await _commentRepository.GetAsync(c => c.Id == createdComment.Id,
            include: c => c.Include(c => c.Post));

        await _mentionService.MentionMembers(user, comment);
        await _alarmService.Alert(AlarmType.COMMENT, comment.UserId, getComment.Post.UserId, getComment.PostId,
            getComment.Id);
        return getComment;
    }

    public async Task DeleteAllInPost(Post post)
    {
        IList<Comment> comments = (await _commentRepository.GetListAsync(c=>c.PostId == post.Id)).Items;
        await _commentRepository.DeleteRangeAsync(comments);
    }
}