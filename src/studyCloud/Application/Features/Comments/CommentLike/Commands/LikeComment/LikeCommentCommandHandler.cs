using Application.Abstractions.Services;
using Application.Repositories.Services.Comments;
using AutoMapper;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Comments.CommentLike.Commands.LikeComment;

public class LikeCommentCommandHandler:IRequestHandler<LikeCommentCommandRequest,LikeCommentCommandResponse>
{
    private readonly ICommentLikeRepository _commentLikeRepository;
    private readonly IAlarmService _alarmService;
    private readonly IMapper _mapper;


    public LikeCommentCommandHandler(ICommentLikeRepository commentLikeRepository, IMapper mapper, IAlarmService alarmService)
    {
        _commentLikeRepository = commentLikeRepository;
        _mapper = mapper;
        _alarmService = alarmService;
    }

    public async Task<LikeCommentCommandResponse> Handle(LikeCommentCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Comments.CommentLike mappedCommentLike = _mapper.Map<Domain.Entities.Comments.CommentLike>(request);
        Domain.Entities.Comments.CommentLike createdCommentLike = await _commentLikeRepository.AddAsync(mappedCommentLike);
        Domain.Entities.Comments.CommentLike? comment = await _commentLikeRepository.GetAsync(c => c.Id == createdCommentLike.Id,
            include:c=>c.Include(c=>c.Comment).ThenInclude(c=>c.Post));
        await _alarmService.Alert(AlarmType.LIKE_COMMENT,comment.UserId,comment.Comment.Post.UserId,comment.Comment.PostId,comment.Comment.Id);
        LikeCommentCommandResponse mappedCreateCommentLikeDto = _mapper.Map<LikeCommentCommandResponse>(createdCommentLike);
        return mappedCreateCommentLikeDto;
    }
}