using Application.Features.Feeds.PostImage.Dtos;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostImage.Queries.GetByIdPostImage;

public class GetByIdPostImageQueryHandler:IRequestHandler<GetByIdPostImageQueryRequest,GetByIdPostFileQueryResponse>
{
    private readonly IPostImageRepository _postImageRepository;
    private IMapper _mapper;

    public GetByIdPostImageQueryHandler(IPostImageRepository postImageRepository, IMapper mapper)
    {
        _postImageRepository = postImageRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdPostFileQueryResponse> Handle(GetByIdPostImageQueryRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.PostImage? postImage =
            await _postImageRepository.GetAsync(c => c.Id == request.Id);
        GetByIdPostFileQueryResponse getByIdPostImageDto =
            _mapper.Map<GetByIdPostFileQueryResponse>(postImage);
        return getByIdPostImageDto;
    }
}