using Application.Repositories.Services.Feeds;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.PostLike.Queries.GetMembersLikedPost;

public class
    GetMembersLikedPostQueryHandler : IRequestHandler<GetMembersLikedPostQueryRequest,
        List<GetMembersLikedPostQueryResponse>>
{
    private readonly IPostLikeRepository _postLikeRepository;
    private IMapper _mapper;

    public GetMembersLikedPostQueryHandler(IPostLikeRepository postLikeRepository, IMapper mapper)
    {
        _postLikeRepository = postLikeRepository;
        _mapper = mapper;
    }

    public async Task<List<GetMembersLikedPostQueryResponse>> Handle(GetMembersLikedPostQueryRequest request,
        CancellationToken cancellationToken)
    {
        List<Domain.Entities.Feeds.PostLike> post = await _postLikeRepository.GetAllAsync(
            c => c.PostId == request.PostId,
            include: c => c.Include(c => c.User)
                .ThenInclude(c => c.UserImageFiles));
        List<GetMembersLikedPostQueryResponse>? mappedPost = _mapper.Map<List<GetMembersLikedPostQueryResponse>>(post);
        return mappedPost;
    }
}