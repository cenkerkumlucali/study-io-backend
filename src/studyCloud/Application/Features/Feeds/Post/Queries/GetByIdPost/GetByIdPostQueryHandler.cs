using Application.Repositories.Services.Feeds;
using AutoMapper;
using Domain.Entities.Comments;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Feeds.Post.Queries.GetByIdPost;

public class GetByIdPostQueryHandler : IRequestHandler<GetByIdPostQueryRequest, GetByIdPostQueryResponse>
{
    private IPostRepository _postRepository;
    private IMapper _mapper;

    public GetByIdPostQueryHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdPostQueryResponse> Handle(GetByIdPostQueryRequest request,
        CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.Post? post =
            await _postRepository.GetAsync(c => c.Id == request.Id,
                i => i.Include(u => u.User)
                    .Include(c => c.Comments)
                    .ThenInclude(c => c.CommentLikes));

        if (post?.Comments is not null) post.Comments = post?.Comments.Where(c => c.ParentId == null).ToList();
        GetByIdPostQueryResponse getByIdPostDto =
            _mapper.Map<GetByIdPostQueryResponse>(post);
        return getByIdPostDto;
    }
}