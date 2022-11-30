using MediatR;

namespace Application.Features.Auths.Commands.DisableEmailAuthenticator;

public class DisableEmailAuthenticatorCommandRequest : IRequest
{
    public int UserId { get; set; }

    
}