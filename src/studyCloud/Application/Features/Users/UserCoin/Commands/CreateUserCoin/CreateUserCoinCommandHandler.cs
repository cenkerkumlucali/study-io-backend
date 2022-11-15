using Application.Features.Users.UserCoin.Dtos;
using Application.Services.Repositories.Users;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.UserCoin.Commands.CreateUserCoin;

public class CreateUserCoinCommandHandler : IRequestHandler<CreateUserCoinCommandRequest, CreateUserCoinCommandResponse>
{
    private readonly IUserCoinRepository _userCoinRepository;
    private readonly IMapper _mapper;


    public CreateUserCoinCommandHandler(IUserCoinRepository userCoinRepository, IMapper mapper)
    {
        _userCoinRepository = userCoinRepository;
        _mapper = mapper;
    }

    public async Task<CreateUserCoinCommandResponse> Handle(CreateUserCoinCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Users.UserCoin mappedUserCoin = _mapper.Map<Domain.Entities.Users.UserCoin>(request);
        Domain.Entities.Users.UserCoin createdUserCoin = await _userCoinRepository.AddAsync(mappedUserCoin);
        CreateUserCoinCommandResponse mappedCreateUserCoinDto = _mapper.Map<CreateUserCoinCommandResponse>(createdUserCoin);
        return mappedCreateUserCoinDto;
    }
}