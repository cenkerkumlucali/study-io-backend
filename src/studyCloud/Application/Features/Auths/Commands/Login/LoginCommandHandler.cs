using Application.Abstractions.Services;
using Application.DTOs.JWT;
using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Repositories.Services.Users;
using AutoMapper;
using Domain.Entities.Users;
using Domain.Enums;
using MediatR;

namespace Application.Features.Auths.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
    private readonly IAuthService _authService;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public LoginCommandHandler(IAuthService authService,
        AuthBusinessRules authBusinessRules, IMapper mapper, IUserRepository userRepository)
    {
        _authService = authService;
        _authBusinessRules = authBusinessRules;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        User? user =
            await _userRepository.GetAsync(user => user.Email == request.UserForLoginDto.Email);
            
        await _authBusinessRules.UserShouldBeExists(user);
        await _authBusinessRules.UserPasswordShouldBeMatch(user.Id, request.UserForLoginDto.Password);
        if (user.AuthenticatorType != AuthenticatorType.None)
        {
                
        }
        AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
        RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IPAddress);
        RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

        LoginCommandResponse loginCommandResponse = new()
        {
            AccessToken = createdAccessToken,
            RefreshToken = addedRefreshToken
        };
        return loginCommandResponse;
    }
}