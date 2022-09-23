using Application.Features.Users.UserCoin.Dtos;
using Application.Services.Repositories.Users;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.UserCoin.Commands.DeleteUserCoin;

public class DeleteUserCoinCommand:IRequest<DeletedUserCoinDto>
{
    public int Id { get; set; }
    public class DeleteUserCoinCommandHandler:IRequestHandler<DeleteUserCoinCommand,DeletedUserCoinDto>
    {
        private readonly IUserCoinRepository _userCoinRepository;
        private IMapper _mapper;

        public DeleteUserCoinCommandHandler(IUserCoinRepository userCoinRepository, IMapper mapper)
        {
            _userCoinRepository = userCoinRepository;
            _mapper = mapper;
        }

        public async Task<DeletedUserCoinDto> Handle(DeleteUserCoinCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Users.UserCoin userCoin = _mapper.Map<Domain.Entities.Users.UserCoin>(request);
            Domain.Entities.Users.UserCoin deletedUserCoin =
                await _userCoinRepository.DeleteAsync(userCoin);
            DeletedUserCoinDto deletedUserCoinDto =
                _mapper.Map<DeletedUserCoinDto>(deletedUserCoin);
            return deletedUserCoinDto;
        }
    }
}