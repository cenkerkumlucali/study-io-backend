using Application.Abstractions.Services;
using Application.DTOs.JWT;
using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Repositories.Services.Users;
using Application.Security.Hashing;
using Domain.Entities.Users;
using MediatR;

namespace Application.Features.Auths.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    private readonly AuthBusinessRules _authBusinessRules;

    public RegisterCommandHandler(IUserRepository userRepository, IAuthService authService,
        AuthBusinessRules authBusinessRules)
    {
        _userRepository = userRepository;
        _authService = authService;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);
        User newUser = new()
        {
            Email = request.UserForRegisterDto.Email,
            FirstName = request.UserForRegisterDto.FirstName,
            LastName = request.UserForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
        };
        User createdUser = await _userRepository.AddAsync(newUser);

        AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

        RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IPAddress);
        RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

        RegisterCommandResponse registeredDto = new()
            { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
        return registeredDto;
    }
}