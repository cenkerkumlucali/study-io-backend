using Application.DTOs.JWT;

namespace Application.Features.Auths.Commands.Register;

public class RegisterCommandResponse
{
    public AccessToken AccessToken { get; set; }
    public Domain.Entities.Users.RefreshToken RefreshToken { get; set; }
}