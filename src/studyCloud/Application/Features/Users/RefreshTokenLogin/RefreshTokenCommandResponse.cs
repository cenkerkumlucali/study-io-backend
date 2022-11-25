using Application.DTOs.JWT;

namespace Application.Features.Users.RefreshTokenLogin;

public class RefreshTokenCommandResponse
{
    public AccessToken Token { get; set; }

}