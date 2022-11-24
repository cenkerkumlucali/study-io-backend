using System.Globalization;
using System.Text;
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

    public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request,
        CancellationToken cancellationToken)
    {
        await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);

        var registeredDto = await _authService.Register(request.UserForRegisterDto, request.IPAddress);
        return registeredDto;
    }
}