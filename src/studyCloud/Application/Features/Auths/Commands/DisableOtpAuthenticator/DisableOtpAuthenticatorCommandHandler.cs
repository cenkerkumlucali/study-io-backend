using Application.Abstractions.Services;
using Application.Features.Auths.Rules;
using Domain.Entities.Users;
using Domain.Enums;
using MediatR;

namespace Application.Features.Auths.Commands.DisableOtpAuthenticator;

public class DisableOtpAuthenticatorCommandHandler : IRequestHandler<DisableOtpAuthenticatorCommandRequest>
{
    private IUserService _userService;
    private IAuthService _authService;
    private AuthBusinessRules _authBusinessRules;

    public DisableOtpAuthenticatorCommandHandler(IUserService userService, IAuthService authService,
        AuthBusinessRules authBusinessRules)
    {
        _userService = userService;
        _authService = authService;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<Unit> Handle(DisableOtpAuthenticatorCommandRequest request, CancellationToken cancellationToken)
    {
        User user = await _userService.GetById(request.UserId);
        await _authBusinessRules.UserShouldBeExists(user);
        await _authBusinessRules.UserShouldBeHaveAuthenticator(user);

        user.AuthenticatorType = AuthenticatorType.None;
        await _authService.DeleteOldOtpAuthenticators(user);
        await _userService.Update(user);

        return Unit.Value;
    }
}