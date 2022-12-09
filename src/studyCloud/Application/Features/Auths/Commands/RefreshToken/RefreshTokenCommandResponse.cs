using Application.DTOs.JWT;

namespace Application.Features.Auths.Commands.RefreshToken;

public class RefreshTokenCommandResponse
{
    public AccessToken AccessToken { get; set; }
}