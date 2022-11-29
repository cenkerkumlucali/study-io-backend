using Application.Abstractions.Services;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Block.Queries.GetByUserId;

public class GetByUserIdQueryHandler:IRequestHandler<GetByUserIdQueryRequest,List<GetByUserIdQueryResponse>>
{
    private readonly IBlockService _blockService;
    private IMapper _mapper;

    public GetByUserIdQueryHandler(IBlockService blockService, IMapper mapper)
    {
        _blockService = blockService;
        _mapper = mapper;
    }

    public async Task<List<GetByUserIdQueryResponse>> Handle(GetByUserIdQueryRequest request, CancellationToken cancellationToken)
    {
        List<Domain.Entities.Users.Block> blockedUser = await _blockService.GetByUserId(request.UserId);
        List<GetByUserIdQueryResponse>? mappedBlockedUser = _mapper.Map<List<GetByUserIdQueryResponse>>(blockedUser);
        return mappedBlockedUser;
    }
}