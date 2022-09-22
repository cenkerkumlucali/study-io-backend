using Application.Features.Feeds.Post.Models;
using Application.Features.Feeds.PostImage.Models;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Feeds.PostImage.Queries.GetListPostImage;

public class GetListPostImageQuery : IRequest<PostImageListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListPostImageQueryHandler : IRequestHandler<GetListPostImageQuery, PostImageListModel>
    {
        private readonly IPostImageRepository _postImageRepository;
        private IMapper _mapper;

        public GetListPostImageQueryHandler(IPostImageRepository postImageRepository, IMapper mapper)
        {
            _postImageRepository = postImageRepository;
            _mapper = mapper;
        }

        public async Task<PostImageListModel> Handle(GetListPostImageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Domain.Entities.Feeds.PostImage> postImage =
                await _postImageRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
            PostImageListModel mappedPostImageListModel =
                _mapper.Map<PostImageListModel>(postImage);
            return mappedPostImageListModel;
        }
    }
}