using Application.DTOs.JWT;
using Domain.Entities.Users;

namespace Application.Features.Auths.Dtos;

public class RefreshedTokensDto
{
    public AccessToken AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }
}