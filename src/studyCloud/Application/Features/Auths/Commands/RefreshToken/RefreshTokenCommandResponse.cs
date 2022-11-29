using Application.DTOs.JWT;

namespace Application.Features.Auths.Commands.RefreshTokenLogin;

public class RefreshTokenCommandResponse
{
    public AccessToken AccessToken { get; set; }
}