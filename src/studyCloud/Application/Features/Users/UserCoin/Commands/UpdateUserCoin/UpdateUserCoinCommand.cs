using Application.Features.Users.UserCoin.Dtos;
using Application.Services.Repositories.Users;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.UserCoin.Commands.UpdateUserCoin;

public class UpdateUserCoinCommand : IRequest<UpdatedUserCoinDto>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int Coin { get; set; }

    public class UpdateUserCoinCommandHandler : IRequestHandler<UpdateUserCoinCommand, UpdatedUserCoinDto>
    {
        private readonly IUserCoinRepository _userCoinRepository;
        private IMapper _mapper;

        public UpdateUserCoinCommandHandler(IUserCoinRepository userCoinRepository, IMapper mapper)
        {
            _userCoinRepository = userCoinRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedUserCoinDto> Handle(UpdateUserCoinCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Users.UserCoin userCoin = _mapper.Map<Domain.Entities.Users.UserCoin>(request);
            Domain.Entities.Users.UserCoin createdUserCoin =
                await _userCoinRepository.UpdateAsync(userCoin);
            UpdatedUserCoinDto updatedUserCoinDto =
                _mapper.Map<UpdatedUserCoinDto>(createdUserCoin);
            return updatedUserCoinDto;
        }
    }
}