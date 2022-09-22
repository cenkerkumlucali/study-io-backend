using Application.Features.Feeds.PostLike.Dtos;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostLike.Queries.GetByIdPostLike;

public class GetByIdPostLikeQuery:IRequest<GetByIdPostLikeDto>
{
    public int Id { get; set; }
    public class GetByIdPostLikeQueryHandler:IRequestHandler<GetByIdPostLikeQuery,GetByIdPostLikeDto>
    {
        private readonly IPostLikeRepository _postLikeRepository;
        private IMapper _mapper;

        public GetByIdPostLikeQueryHandler(IPostLikeRepository postLikeRepository, IMapper mapper)
        {
            _postLikeRepository = postLikeRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdPostLikeDto> Handle(GetByIdPostLikeQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Feeds.PostLike? postLike =
                await _postLikeRepository.GetAsync(c => c.Id == request.Id);
            GetByIdPostLikeDto getByIdPostLikeDto =
                _mapper.Map<GetByIdPostLikeDto>(postLike);
            return getByIdPostLikeDto;
        }
    }
}