using Application.Repositories.Services.Feeds;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Post.Queries.GetByIdPost;

public class GetByIdPostQueryHandler : IRequestHandler<GetByIdPostQueryRequest, GetByIdPostQueryResponse>
{
    private readonly IPostRepository _postRepository;
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
                    .ThenInclude(c=>c.UserImageFiles)
                    .Include(c => c.PostImageFiles)
                    .Include(c => c.Comments)
                    .ThenInclude(c => c.CommentImageFiles)
                    .Include(c => c.Comments)
                    .ThenInclude(c => c.CommentLikes)
                    .Include(c=>c.PostLikes));

        if (post?.Comments is not null) post.Comments = post?.Comments.Where(c => c.ParentId == null).ToList();
        
        GetByIdPostQueryResponse getByIdPostQueryResponse =
            _mapper.Map<GetByIdPostQueryResponse>(post);
        return getByIdPostQueryResponse;
    }
}