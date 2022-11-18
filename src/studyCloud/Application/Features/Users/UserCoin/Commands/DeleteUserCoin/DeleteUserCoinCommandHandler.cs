using Application.Repositories.Services.Users;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.UserCoin.Commands.DeleteUserCoin;

public class DeleteUserCoinCommandHandler:IRequestHandler<DeleteUserCoinCommandRequest,DeleteUserCoinCommandResponse>
{
    private readonly IUserCoinRepository _userCoinRepository;
    private IMapper _mapper;

    public DeleteUserCoinCommandHandler(IUserCoinRepository userCoinRepository, IMapper mapper)
    {
        _userCoinRepository = userCoinRepository;
        _mapper = mapper;
    }

    public async Task<DeleteUserCoinCommandResponse> Handle(DeleteUserCoinCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Users.UserCoin userCoin = _mapper.Map<Domain.Entities.Users.UserCoin>(request);
        Domain.Entities.Users.UserCoin deletedUserCoin =
            await _userCoinRepository.DeleteAsync(userCoin);
        DeleteUserCoinCommandResponse deletedUserCoinDto =
            _mapper.Map<DeleteUserCoinCommandResponse>(deletedUserCoin);
        return deletedUserCoinDto;
    }
}