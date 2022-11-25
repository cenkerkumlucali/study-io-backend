using Application.DTOs.JWT;
using Application.DTOs.User;
using Application.Features.Auths.Commands.Register;
using Domain.Entities.Users;

namespace Application.Abstractions.Services;

public interface IAuthService
{
    Task<RegisterCommandResponse> Register(UserForRegisterDto userForRegisterDto, string iPAddress);
    Task<AccessToken> CreateAccessToken(User user);
    Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);
    Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
    Task<AccessToken> RefreshTokenLoginAsync(string refreshToken);

}