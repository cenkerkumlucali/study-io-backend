using Application.Abstractions.Services;
using Application.Repositories.Services.Feeds;
using AutoMapper;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Feeds.PostLike.Commands.UnLikePost;

public class UnLikePostCommandHandler:IRequestHandler<UnLikePostCommandRequest,UnLikePostCommandResponse>
{
    private readonly IPostLikeRepository _postLikeRepository;
    private readonly IAlarmService _alarmService;
    private IMapper _mapper;

    public UnLikePostCommandHandler(IPostLikeRepository postLikeRepository, IMapper mapper, IAlarmService alarmService)
    {
        _postLikeRepository = postLikeRepository;
        _mapper = mapper;
        _alarmService = alarmService;
    }

    public async Task<UnLikePostCommandResponse> Handle(UnLikePostCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.PostLike? postLike = await _postLikeRepository.GetAsync(c => c.UserId == request.UserId && c.PostId == request.PostId,
            include:c=>c.Include(c=>c.Post));
        Domain.Entities.Feeds.PostLike deletedPostLike = await _postLikeRepository.DeleteAsync(postLike);
        await _alarmService.DeletePost(AlarmType.LIKE_POST,request.UserId,postLike.Post.UserId,postLike.PostId);
        UnLikePostCommandResponse deletedPostLikeDto = _mapper.Map<UnLikePostCommandResponse>(deletedPostLike);
        return deletedPostLikeDto;
    }
}