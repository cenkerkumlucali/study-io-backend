using Application.DTOs.JWT;
using Domain.Entities.Users;
using Domain.Enums;

namespace Application.Features.Auths.Commands.Login;

public class LoginCommandResponse
{
    public AccessToken? AccessToken { get; set; }
    public Domain.Entities.Users.RefreshToken? RefreshToken { get; set; }

    public AuthenticatorType? RequiredAuthenticatorType { get; set; }
}