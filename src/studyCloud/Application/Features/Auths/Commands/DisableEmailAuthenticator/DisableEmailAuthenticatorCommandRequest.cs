using MediatR;

namespace Application.Features.Auths.Commands.DisableEmailAuthenticator;

public class DisableEmailAuthenticatorCommandRequest : IRequest
{
    public long UserId { get; set; }

    
}