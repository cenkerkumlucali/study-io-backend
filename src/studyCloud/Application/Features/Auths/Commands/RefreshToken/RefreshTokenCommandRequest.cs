using MediatR;

namespace Application.Features.Auths.Commands.RefreshToken;

public class RefreshTokenCommandRequest:IRequest<RefreshTokenCommandResponse>
{
    public string RefreshToken { get; set; }
    public string IPAddress { get; set; }
}