using Application.Features.Feeds.Post.Dtos;
using Application.Features.Feeds.PostImage.Dtos;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostImage.Queries.GetByIdPostImage;

public class GetByIdPostImageQuery:IRequest<GetByIdPostImageDto>
{
    public int Id { get; set; }
    public class GetByIdPostImageQueryHandler:IRequestHandler<GetByIdPostImageQuery,GetByIdPostImageDto>
    {
        private readonly IPostImageRepository _postImageRepository;
        private IMapper _mapper;

        public GetByIdPostImageQueryHandler(IPostImageRepository postImageRepository, IMapper mapper)
        {
            _postImageRepository = postImageRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdPostImageDto> Handle(GetByIdPostImageQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Feeds.PostImage? postImage =
                await _postImageRepository.GetAsync(c => c.Id == request.Id);
            GetByIdPostImageDto getByIdPostImageDto =
                _mapper.Map<GetByIdPostImageDto>(postImage);
            return getByIdPostImageDto;
        }
    }
}