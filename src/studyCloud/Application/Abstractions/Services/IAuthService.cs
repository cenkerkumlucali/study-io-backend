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
    Task<RefreshToken?> GetRefreshTokenByToken(string token);
    Task DeleteOldEmailAuthenticators(User user);
    Task<Domain.Entities.Users.EmailAuthenticator> CreateEmailAuthenticator(User user);
    Task<Domain.Entities.Users.OtpAuthenticator> CreateOtpAuthenticator(User user);
    Task DeleteOldOtpAuthenticators(User user);
    Task<string> ConvertSecretKeyToString(byte[] secretKey);
    Task VerifyAuthenticatorCode(User user, string AuthenticatorCode);
    Task SendAuthenticatorCode(User user);

}