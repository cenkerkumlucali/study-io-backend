using Application.Features.Users.UserCoin.Dtos;
using Application.Services.Repositories.Users;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.UserCoin.Commands.UpdateUserCoin;

public class UpdateUserCoinCommandHandler : IRequestHandler<UpdateUserCoinCommandRequest, UpdateUserCoinCommandResponse>
{
    private readonly IUserCoinRepository _userCoinRepository;
    private IMapper _mapper;

    public UpdateUserCoinCommandHandler(IUserCoinRepository userCoinRepository, IMapper mapper)
    {
        _userCoinRepository = userCoinRepository;
        _mapper = mapper;
    }

    public async Task<UpdateUserCoinCommandResponse> Handle(UpdateUserCoinCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Users.UserCoin userCoin = _mapper.Map<Domain.Entities.Users.UserCoin>(request);
        Domain.Entities.Users.UserCoin createdUserCoin =
            await _userCoinRepository.UpdateAsync(userCoin);
        UpdateUserCoinCommandResponse updatedUserCoinDto =
            _mapper.Map<UpdateUserCoinCommandResponse>(createdUserCoin);
        return updatedUserCoinDto;
    }
}