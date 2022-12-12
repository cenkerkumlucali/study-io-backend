using Application.Abstractions.Services;
using Application.Repositories.Services.Feeds;
using AutoMapper;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.PostLike.Commands.LikePost;

public class LikePostCommandHandler:IRequestHandler<LikePostCommandRequest,LikePostCommandResponse>
{
    private readonly IPostLikeRepository _postLikeRepository;
    private readonly IAlarmService _alarmService;
    private readonly IMapper _mapper;


    public LikePostCommandHandler(IPostLikeRepository postLikeRepository, IMapper mapper, IAlarmService alarmService)
    {
        _postLikeRepository = postLikeRepository;
        _mapper = mapper;
        _alarmService = alarmService;
    }

    public async Task<LikePostCommandResponse> Handle(LikePostCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.PostLike mappedPostLike = _mapper.Map<Domain.Entities.Feeds.PostLike>(request);
        Domain.Entities.Feeds.PostLike createdPostLike = await _postLikeRepository.AddAsync(mappedPostLike);
        Domain.Entities.Feeds.PostLike? post = await _postLikeRepository.GetAsync(c => c.PostId == createdPostLike.PostId,
            include:c=>c.Include(c=>c.Post));
        await _alarmService.Alert(AlarmType.LIKE_POST,request.UserId,post.Post.UserId,post.Id);
        LikePostCommandResponse mappedCreatePostLikeDto = _mapper.Map<LikePostCommandResponse>(createdPostLike);
        return mappedCreatePostLikeDto;
    }
}