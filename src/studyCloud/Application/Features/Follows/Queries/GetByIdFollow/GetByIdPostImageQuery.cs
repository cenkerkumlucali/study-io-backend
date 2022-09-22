using Application.Features.Feeds.PostImage.Dtos;
using Application.Features.Follows.Dtos;
using Application.Services.Repositories.Feeds;
using Application.Services.Repositories.Follows;
using AutoMapper;
using Domain.Entities.Follow;
using MediatR;

namespace Application.Features.Follows.Queries.GetByIdFollow;

public class GetByIdFollowQuery:IRequest<GetByIdFollowDto>
{
    public int Id { get; set; }
    public class GetByIdFollowQueryHandler:IRequestHandler<GetByIdFollowQuery,GetByIdFollowDto>
    {
        private readonly IFollowRepository _followRepository;
        private IMapper _mapper;

        public GetByIdFollowQueryHandler(IFollowRepository followRepository, IMapper mapper)
        {
            _followRepository = followRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdFollowDto> Handle(GetByIdFollowQuery request, CancellationToken cancellationToken)
        {
            Follow? follow =
                await _followRepository.GetAsync(c => c.Id == request.Id);
            GetByIdFollowDto getByIdFollowDto =
                _mapper.Map<GetByIdFollowDto>(follow);
            return getByIdFollowDto;
        }
    }
}