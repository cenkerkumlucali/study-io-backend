using Application.Abstractions.Services.Paging;
using Application.Features.Feeds.PostImage.Models;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostImage.Queries.GetListPostImage;

public class GetListPostImageQueryHandler : IRequestHandler<GetListPostImageQueryRequest, PostImageListModel>
{
    private readonly IPostImageRepository _postImageRepository;
    private IMapper _mapper;

    public GetListPostImageQueryHandler(IPostImageRepository postImageRepository, IMapper mapper)
    {
        _postImageRepository = postImageRepository;
        _mapper = mapper;
    }

    public async Task<PostImageListModel> Handle(GetListPostImageQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<Domain.Entities.Feeds.PostImage> postImage =
            await _postImageRepository.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
        PostImageListModel mappedPostImageListModel =
            _mapper.Map<PostImageListModel>(postImage);
        return mappedPostImageListModel;
    }
}