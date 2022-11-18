using Application.DTOs.JWT;
using Domain.Entities.Users;

namespace Application.Abstractions.Services;

public interface IAuthService
{
    public Task<AccessToken> CreateAccessToken(User user);
    public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);
    public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
}