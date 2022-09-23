using Application.Features.Users.UserCoin.Dtos;
using Application.Services.Repositories.Users;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.UserCoin.Commands.CreateUserCoin;

public class CreateUserCoinCommand : IRequest<CreatedUserCoinDto>
{
    public int UserId { get; set; }
    public int Coin { get; set; }

    public class CreateUserCoinCommandHandler : IRequestHandler<CreateUserCoinCommand, CreatedUserCoinDto>
    {
        private readonly IUserCoinRepository _userCoinRepository;
        private readonly IMapper _mapper;


        public CreateUserCoinCommandHandler(IUserCoinRepository userCoinRepository, IMapper mapper)
        {
            _userCoinRepository = userCoinRepository;
            _mapper = mapper;
        }

        public async Task<CreatedUserCoinDto> Handle(CreateUserCoinCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Users.UserCoin mappedUserCoin = _mapper.Map<Domain.Entities.Users.UserCoin>(request);
            Domain.Entities.Users.UserCoin createdUserCoin = await _userCoinRepository.AddAsync(mappedUserCoin);
            CreatedUserCoinDto mappedCreateUserCoinDto = _mapper.Map<CreatedUserCoinDto>(createdUserCoin);
            return mappedCreateUserCoinDto;
        }
    }
}