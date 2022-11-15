using Application.Features.Feeds.Post.Dtos;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

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
            await _postRepository.GetAsync(c => c.Id == request.Id);
        GetByIdPostQueryResponse getByIdPostDto =
            _mapper.Map<GetByIdPostQueryResponse>(post);
        return getByIdPostDto;
    }
}