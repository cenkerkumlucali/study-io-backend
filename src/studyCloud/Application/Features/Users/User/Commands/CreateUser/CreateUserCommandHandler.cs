using Application.Features.Users.User.Dtos;
using Application.Features.Users.User.Rules;
using Application.Repositories.Services.Users;
using Application.Security.Hashing;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper,
        UserBusinessRules userBusinessRules)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Users.User mappedUser = _mapper.Map<Domain.Entities.Users.User>(request);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
        mappedUser.PasswordHash = passwordHash;
        mappedUser.PasswordSalt = passwordSalt;

        Domain.Entities.Users.User createdUser = await _userRepository.AddAsync(mappedUser);
        CreateUserCommandResponse createdUserDto = _mapper.Map<CreateUserCommandResponse>(createdUser);
        return createdUserDto;
    }
}