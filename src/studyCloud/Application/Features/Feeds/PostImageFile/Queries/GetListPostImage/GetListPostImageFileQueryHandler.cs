using Application.Abstractions.Services.Paging;
using Application.Features.Feeds.PostImageFile.Models;
using Application.Repositories.Services.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostImageFile.Queries.GetListPostImage;

public class GetListPostImageFileQueryHandler : IRequestHandler<GetListPostImageFileQueryRequest, PostImageListModel>
{
    private readonly IPostImageFileRepository _postImageRepository;
    private IMapper _mapper;

    public GetListPostImageFileQueryHandler(IPostImageFileRepository postImageRepository, IMapper mapper)
    {
        _postImageRepository = postImageRepository;
        _mapper = mapper;
    }

    public async Task<PostImageListModel> Handle(GetListPostImageFileQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<Domain.Entities.ImageFile.PostImageFile> postImage =
            await _postImageRepository.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
        PostImageListModel mappedPostImageListModel =
            _mapper.Map<PostImageListModel>(postImage);
        return mappedPostImageListModel;
    }
}