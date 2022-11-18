using Application.Abstractions.Services.Paging;
using Application.DTOs.Post;
using Application.Features.Feeds.Post.Models;
using Application.Repositories.Services.Comments;
using Application.Repositories.Services.Feeds;
using AutoMapper;
using Domain.Entities.Comments;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Feeds.Post.Queries.GetListPost;

public class GetListPostQueryHandler : IRequestHandler<GetListPostQueryRequest, PostListModel>
{
    private IPostRepository _postRepository;
    private ICommentRepository _commentRepository;
    private IMapper _mapper;

    public GetListPostQueryHandler(IPostRepository postRepository, IMapper mapper, ICommentRepository commentRepository)
    {
        _postRepository = postRepository;
        _mapper = mapper;
        _commentRepository = commentRepository;
    }

    public async Task<PostListModel> Handle(GetListPostQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<Domain.Entities.Feeds.Post> post =
            await _postRepository.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize,
                include: c => c.Include(c => c.User)
                    .Include(c => c.Comments)
                    .ThenInclude(c => c.User));
       
        
        PostListModel mappedPostListModel =
            _mapper.Map<PostListModel>(post);
        return mappedPostListModel;
    }
}