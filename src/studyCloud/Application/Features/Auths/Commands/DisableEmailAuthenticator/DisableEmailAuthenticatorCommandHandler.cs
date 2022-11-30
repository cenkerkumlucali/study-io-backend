using Application.Abstractions.Services;
using Application.Features.Auths.Rules;
using Domain.Entities.Users;
using Domain.Enums;
using MediatR;

namespace Application.Features.Auths.Commands.DisableEmailAuthenticator;

public class DisableEmailAuthenticatorCommandHandler : IRequestHandler<DisableEmailAuthenticatorCommandRequest>
{
    private IUserService _userService;
    private IAuthService _authService;
    private AuthBusinessRules _authBusinessRules;

    public DisableEmailAuthenticatorCommandHandler(IUserService userService, IAuthService authService,
        AuthBusinessRules authBusinessRules)
    {
        _userService = userService;
        _authService = authService;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<Unit> Handle(DisableEmailAuthenticatorCommandRequest request, CancellationToken cancellationToken)
    {
        User user = await _userService.GetById(request.UserId);
        await _authBusinessRules.UserShouldBeExists(user);
        await _authBusinessRules.UserShouldBeHaveAuthenticator(user);

        user.AuthenticatorType = AuthenticatorType.None;
        await _authService.DeleteOldEmailAuthenticators(user);
        await _userService.Update(user);

        return Unit.Value;
    }
}