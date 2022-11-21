using Application.Abstractions.Services.Paging;
using Application.Features.Feeds.Post.Models;
using Application.Repositories.Services.Feeds;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Feeds.Post.Queries.GetListPost;

public class GetListPostQueryHandler : IRequestHandler<GetListPostQueryRequest, PostListModel>
{
    private IPostRepository _postRepository;
    private IMapper _mapper;

    public GetListPostQueryHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
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