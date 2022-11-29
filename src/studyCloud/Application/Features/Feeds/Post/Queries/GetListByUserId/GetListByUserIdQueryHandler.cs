using Application.Abstractions.Services;
using MediatR;

namespace Application.Features.Feeds.Post.Queries.GetListByUserId;

public class GetListByUserIdQueryHandler : IRequestHandler<GetListByUserIdQueryRequest, GetListByUserIdQueryResponse>
{
    private readonly IPostService _postService;

    public GetListByUserIdQueryHandler(IPostService postService)
    {
        _postService = postService;
    }

    public async Task<GetListByUserIdQueryResponse> Handle(GetListByUserIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        List<object> posts =
            await _postService.GetPostPageOfFollowingMembersByUserId(request.UserId, request.Page, request.Size);
        return new GetListByUserIdQueryResponse()
        {
            Posts = posts
        };
    }
}