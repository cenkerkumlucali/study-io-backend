using MediatR;

namespace Application.Features.Auths.Commands.VerifyEmailAuthenticator;

public class VerifyEmailAuthenticatorCommandRequest : IRequest
{
    public string ActivationKey { get; set; }

}