using Application.Features.Users.User.Dtos;
using Application.Features.Users.User.Rules;
using Application.Repositories.Services.Users;
using Application.Security.Hashing;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.User.Commands.UpdateUserFromAuth;

public class UpdateUserFromAuthCommand : IRequest<UpdatedUserFromAuthDto>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string? NewPassword { get; set; }

    public class UpdateUserFromAuthCommandHandler : IRequestHandler<UpdateUserFromAuthCommand, UpdatedUserFromAuthDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public UpdateUserFromAuthCommandHandler(IUserRepository userRepository, IMapper mapper,
                                                UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<UpdatedUserFromAuthDto> Handle(UpdateUserFromAuthCommand request,
                                                         CancellationToken cancellationToken)
        {
            Domain.Entities.Users.User? user = await _userRepository.GetAsync(u => u.Id == request.Id);
            await _userBusinessRules.UserShouldBeExist(user);
            await _userBusinessRules.UserPasswordShouldBeMatch(user, request.Password);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            if (request.NewPassword is not null && !string.IsNullOrWhiteSpace(request.NewPassword))
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            Domain.Entities.Users.User updatedUser = await _userRepository.UpdateAsync(user);
            UpdatedUserFromAuthDto updatedUserFromAuthDto = _mapper.Map<UpdatedUserFromAuthDto>(updatedUser);
            // updatedUserFromAuthDto.AccessToken = await _authService.CreateAccessToken(user);
            return updatedUserFromAuthDto;
        }
    }
}