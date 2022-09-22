using Application.Features.Feeds.Post.Dtos;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.Post.Queries.GetByIdPost;

public class GetByIdPostQuery:IRequest<GetByIdPostDto>
{
    public int Id { get; set; }
    public class GetByIdPostQueryHandler:IRequestHandler<GetByIdPostQuery,GetByIdPostDto>
    {
        private IPostRepository _postRepository;
        private IMapper _mapper;

        public GetByIdPostQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdPostDto> Handle(GetByIdPostQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Feeds.Post? post =
                await _postRepository.GetAsync(c => c.Id == request.Id);
            GetByIdPostDto getByIdPostDto =
                _mapper.Map<GetByIdPostDto>(post);
            return getByIdPostDto;
        }
    }
}