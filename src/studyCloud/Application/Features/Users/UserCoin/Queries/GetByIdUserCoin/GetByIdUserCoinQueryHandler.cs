using Application.Repositories.Services.Users;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.UserCoin.Queries.GetByIdUserCoin;

public class GetByIdUserCoinQueryHandler : IRequestHandler<GetByIdUserCoinQueryRequest, GetByIdUserCoinQueryResponse>
{
    private readonly IUserCoinRepository _userCoinRepository;
    private IMapper _mapper;

    public GetByIdUserCoinQueryHandler(IUserCoinRepository userCoinRepository, IMapper mapper)
    {
        _userCoinRepository = userCoinRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdUserCoinQueryResponse> Handle(GetByIdUserCoinQueryRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Users.UserCoin? userCoin =
            await _userCoinRepository.GetAsync(c => c.Id == request.Id);
        GetByIdUserCoinQueryResponse GetByIdUserCoinQueryResponse =
            _mapper.Map<GetByIdUserCoinQueryResponse>(userCoin);
        return GetByIdUserCoinQueryResponse;
    }
}