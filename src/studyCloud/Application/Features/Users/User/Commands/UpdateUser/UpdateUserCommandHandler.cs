using Application.Features.Users.User.Dtos;
using Application.Features.Users.User.Rules;
using Application.Repositories.Services.Users;
using Application.Security.Hashing;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.User.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper,
        UserBusinessRules userBusinessRules)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Users.User mappedUser = _mapper.Map<Domain.Entities.Users.User>(request);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
        mappedUser.PasswordHash = passwordHash;
        mappedUser.PasswordSalt = passwordSalt;

        Domain.Entities.Users.User updatedUser = await _userRepository.UpdateAsync(mappedUser);
        UpdateUserCommandResponse updatedUserDto = _mapper.Map<UpdateUserCommandResponse>(updatedUser);
        return updatedUserDto;
    }
}