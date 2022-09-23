using Application.Features.Users.UserCoin.Dtos;
using Application.Services.Repositories.Users;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.UserCoin.Queries.GetByIdUserCoin;

public class GetByIdUserCoinQuery : IRequest<GetByIdUserCoinDto>
{
    public int Id { get; set; }
    public class GetByIdUserCoinQueryHandler : IRequestHandler<GetByIdUserCoinQuery, GetByIdUserCoinDto>
    {
        private readonly IUserCoinRepository _userCoinRepository;
        private IMapper _mapper;

        public GetByIdUserCoinQueryHandler(IUserCoinRepository userCoinRepository, IMapper mapper)
        {
            _userCoinRepository = userCoinRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdUserCoinDto> Handle(GetByIdUserCoinQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Users.UserCoin? userCoin =
                await _userCoinRepository.GetAsync(c => c.Id == request.Id);
            GetByIdUserCoinDto getByIdUserCoinDto =
                _mapper.Map<GetByIdUserCoinDto>(userCoin);
            return getByIdUserCoinDto;
        }
    }
}