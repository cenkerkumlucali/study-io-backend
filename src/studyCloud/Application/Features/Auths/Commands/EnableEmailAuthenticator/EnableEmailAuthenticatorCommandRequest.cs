using MediatR;

namespace Application.Features.Auths.Commands.EnableEmailAuthenticator;

public class EnableEmailAuthenticatorCommandRequest : IRequest
{
    public long UserId { get; set; }
    public string? VerifyEmailUrlPrefix { get; set; }
    public int RoutingKey => 1;
}