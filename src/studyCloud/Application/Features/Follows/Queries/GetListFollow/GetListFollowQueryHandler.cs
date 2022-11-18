using Application.Abstractions.Services.Paging;
using Application.Features.Follows.Models;
using Application.Repositories.Services.Follows;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Follows.Queries.GetListFollow;

public class GetListFollowQueryHandler : IRequestHandler<GetListFollowQueryRequest, FollowListModel>
{
    private readonly IFollowRepository _followRepository;
    private IMapper _mapper;

    public GetListFollowQueryHandler(IFollowRepository followRepository, IMapper mapper)
    {
        _followRepository = followRepository;
        _mapper = mapper;
    }

    public async Task<FollowListModel> Handle(GetListFollowQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<Follow> follow =
            await _followRepository.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
        FollowListModel mappedFollowListModel =
            _mapper.Map<FollowListModel>(follow);
        return mappedFollowListModel;
    }
}