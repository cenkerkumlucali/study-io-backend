using Application.Abstractions.Services;
using Application.Abstractions.Services.EmailAuthenticator;
using Application.Abstractions.Services.JWT;
using Application.Abstractions.Services.OtpAuthenticator;
using Application.Abstractions.Services.Paging;
using Application.DTOs.JWT;
using Application.Repositories.Services.RefreshToken;
using Application.Repositories.Services.UserOperationClaim;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services;

public class AuthManager : IAuthService
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly ITokenHelper _tokenHelper;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public AuthManager(IUserOperationClaimRepository userOperationClaimRepository,
        IRefreshTokenRepository refreshTokenRepository, ITokenHelper tokenHelper)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _tokenHelper = tokenHelper;
    }


    public async Task<AccessToken> CreateAccessToken(User user)
    {
        IPaginate<UserOperationClaim> userOperationClaims =
            await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id,
                include: u =>
                    u.Include(u => u.OperationClaim)
            );
        IList<OperationClaim> operationClaims =
            userOperationClaims.Items.Select(u => new OperationClaim
                { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();

        AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
        return accessToken;
    }

    public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
    {
        RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
        return Task.FromResult(refreshToken);
    }

    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
        return addedRefreshToken;
    }
}