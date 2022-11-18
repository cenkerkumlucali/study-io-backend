using Application.Repositories.Services.Feeds;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Feeds.Post.Queries.GetByIdPost;

public class GetByIdPostQueryHandler:IRequestHandler<GetByIdPostQueryRequest,GetByIdPostQueryResponse>
{
    private IPostRepository _postRepository;
    private IMapper _mapper;

    public GetByIdPostQueryHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdPostQueryResponse> Handle(GetByIdPostQueryRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.Post? post =
            await _postRepository.GetAsync(c => c.Id == request.Id,
                c=>c.Include(c=>c.Comments)
                    .Include(c=>c.User));
        GetByIdPostQueryResponse getByIdPostDto =
            _mapper.Map<GetByIdPostQueryResponse>(post);
        return getByIdPostDto;
    }
}