using MediatR;

namespace Application.Features.Auths.Commands.DisableOtpAuthenticator;

public class DisableOtpAuthenticatorCommandRequest : IRequest
{
    public long UserId { get; set; }
}