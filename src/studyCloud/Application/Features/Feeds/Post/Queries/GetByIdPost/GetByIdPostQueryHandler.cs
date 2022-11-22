using Application.Abstractions.Services;
using Application.Abstractions.Storage.AWS;
using Application.Repositories.Services.Feeds;
using AutoMapper;
using Domain.Entities.Comments;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Feeds.Post.Queries.GetByIdPost;

public class GetByIdPostQueryHandler : IRequestHandler<GetByIdPostQueryRequest, GetByIdPostQueryResponse>
{
    private readonly IPostRepository _postRepository;
    private readonly ICommentImageFileService _commentImageFileService;
    private readonly IAwsStorage _awsStorage;
    private IMapper _mapper;

    public GetByIdPostQueryHandler(IPostRepository postRepository, IMapper mapper, IAwsStorage awsStorage, ICommentImageFileService commentImageFileService)
    {
        _postRepository = postRepository;
        _mapper = mapper;
        _awsStorage = awsStorage;
        _commentImageFileService = commentImageFileService;
    }

    public async Task<GetByIdPostQueryResponse> Handle(GetByIdPostQueryRequest request,
        CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.Post? post =
            await _postRepository.GetAsync(c => c.Id == request.Id,
                i => i.Include(u => u.User)
                    .Include(c => c.PostImageFiles)
                    .Include(c => c.Comments)
                    .ThenInclude(c => c.CommentImageFiles)
                    .Include(c => c.Comments)
                    .ThenInclude(c => c.CommentLikes));

        if (post?.Comments is not null) post.Comments = post?.Comments.Where(c => c.ParentId == null).ToList();
        
        GetByIdPostQueryResponse getByIdPostQueryResponse =
            _mapper.Map<GetByIdPostQueryResponse>(post);
        return getByIdPostQueryResponse;
    }
}