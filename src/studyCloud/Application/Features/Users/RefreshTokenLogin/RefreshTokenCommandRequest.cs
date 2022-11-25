using MediatR;

namespace Application.Features.Users.RefreshTokenLogin;

public class RefreshTokenCommandRequest:IRequest<RefreshTokenCommandResponse>
{
    public string RefreshToken { get; set; }
}