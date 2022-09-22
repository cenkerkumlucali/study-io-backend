using Application.Features.Feeds.PostImage.Models;
using Application.Features.Follows.Models;
using Application.Services.Repositories.Feeds;
using Application.Services.Repositories.Follows;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities.Follow;
using MediatR;

namespace Application.Features.Follows.Queries.GetListFollow;

public class GetListFollowQuery : IRequest<FollowListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListFollowQueryHandler : IRequestHandler<GetListFollowQuery, FollowListModel>
    {
        private readonly IFollowRepository _followRepository;
        private IMapper _mapper;

        public GetListFollowQueryHandler(IFollowRepository followRepository, IMapper mapper)
        {
            _followRepository = followRepository;
            _mapper = mapper;
        }

        public async Task<FollowListModel> Handle(GetListFollowQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Follow> follow =
                await _followRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
            FollowListModel mappedFollowListModel =
                _mapper.Map<FollowListModel>(follow);
            return mappedFollowListModel;
        }
    }
}