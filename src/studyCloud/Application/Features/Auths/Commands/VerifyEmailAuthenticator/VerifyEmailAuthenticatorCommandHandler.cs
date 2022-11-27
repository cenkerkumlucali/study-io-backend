using Application.Abstractions.Services;
using Application.Features.Auths.Rules;
using Application.Repositories.Services.Users;
using Domain.Entities.Users;
using Domain.Enums;
using MediatR;

namespace Application.Features.Auths.Commands.VerifyEmailAuthenticator;

public class VerifyEmailAuthenticatorCommandHandler : IRequestHandler<VerifyEmailAuthenticatorCommandRequest>
{
    private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;
    private readonly IUserService _userService;
    private readonly AuthBusinessRules _authBusinessRules;

    public VerifyEmailAuthenticatorCommandHandler(IEmailAuthenticatorRepository emailAuthenticatorRepository,
        AuthBusinessRules authBusinessRules, IUserService userService)
    {
        _emailAuthenticatorRepository = emailAuthenticatorRepository;
        _authBusinessRules = authBusinessRules;
        _userService = userService;
    }

    public async Task<Unit> Handle(VerifyEmailAuthenticatorCommandRequest request, CancellationToken cancellationToken)
    {
        EmailAuthenticator? emailAuthenticator =
            await _emailAuthenticatorRepository.GetAsync(
                e => e.ActivationKey == request.ActivationKey);
        await _authBusinessRules.EmailAuthenticatorShouldBeExists(emailAuthenticator);
        await _authBusinessRules.EmailAuthenticatorActivationKeyShouldBeExists(emailAuthenticator);

        emailAuthenticator.ActivationKey = null;
        emailAuthenticator.IsVerified = true;
        await _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);

        User user = await _userService.GetById(emailAuthenticator.UserId);
        user.AuthenticatorType = AuthenticatorType.Email;
        await _userService.Update(user);

        return Unit.Value;
    }
}