using Application.Abstractions.Services;
using Application.Abstractions.Services.JWT;
using Application.Abstractions.Services.Paging;
using Application.DTOs.JWT;
using Application.DTOs.User;
using Application.Features.Auths.Commands.Register;
using Application.Repositories.Services.OperationClaim;
using Application.Repositories.Services.RefreshToken;
using Application.Repositories.Services.UserOperationClaim;
using Application.Security.Hashing;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Persistence.Operations;

namespace Persistence.Services;

public class AuthManager : IAuthService
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly ITokenHelper _tokenHelper;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IRefreshTokenRepository _redisRefreshTokenRepository;
    private readonly IOperationClaimRepository _operationClaimRepository;

    private readonly IUserService _userService;

    public AuthManager(IUserOperationClaimRepository userOperationClaimRepository,
        IRefreshTokenRepository refreshTokenRepository,
        ITokenHelper tokenHelper,
        IUserService userService,
        IRefreshTokenRepository redisRefreshTokenRepository,
        IOperationClaimRepository operationClaimRepository)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _tokenHelper = tokenHelper;
        _userService = userService;
        _redisRefreshTokenRepository = redisRefreshTokenRepository;
        _operationClaimRepository = operationClaimRepository;
    }


    public async Task<RegisterCommandResponse> Register(UserForRegisterDto userForRegisterDto, string iPAddress)
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
        User newUser = new()
        {
            UserName = $"user{StaticRandom.Instance.Next(30000000, 99999999)}",
            Email = userForRegisterDto.Email,
            FirstName = userForRegisterDto.FirstName,
            LastName = userForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
        };
        User createdUser = await _userService.AddAsync(newUser);

        AccessToken createdAccessToken = await CreateAccessToken(createdUser);

        RefreshToken createdRefreshToken = await CreateRefreshToken(createdUser, iPAddress);
        RefreshToken addedRefreshToken = await AddRefreshToken(createdRefreshToken);

        RegisterCommandResponse registeredDto = new()
            { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
        return registeredDto;
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

        AccessToken accessToken = await _tokenHelper.CreateToken(user, operationClaims);
        return accessToken;
    }

    public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
    {
        RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
        return Task.FromResult(refreshToken);
    }

    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken addedRefreshToken = await _redisRefreshTokenRepository.UpdateAsync(refreshToken);
        return addedRefreshToken;
    }

    public async Task<AccessToken> RefreshTokenLoginAsync(string refreshToken)
    {
        RefreshToken refresh = await _redisRefreshTokenRepository.GetByRefreshToken(refreshToken);
        User user = await _userService.GetById(refresh.UserId);
        if (user is not null && refresh?.Expires > DateTime.UtcNow)
        {
            IPaginate<UserOperationClaim> userOperationClaims =
                await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id,
                    include: u =>
                        u.Include(u => u.OperationClaim)
                );
            IList<OperationClaim> operationClaims =
                userOperationClaims.Items.Select(u => new OperationClaim
                    { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();

            AccessToken accessToken = await _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }
        else
            throw new Exception("RefreshTokenLoginError");
    }
}