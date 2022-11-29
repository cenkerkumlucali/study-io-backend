using Application.Abstractions.Services;
using Application.DTOs.JWT;
using Application.Features.Auths.Rules;
using Domain.Entities.Users;
using MediatR;

namespace Application.Features.Auths.Commands.RefreshTokenLogin;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
{
    private readonly IAuthService _authService;
    private readonly AuthBusinessRules _authBusinessRules;

    public RefreshTokenCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request,CancellationToken cancellationToken)
    {
        RefreshToken? refreshToken = await _authService.GetRefreshTokenByToken(request.RefreshToken);
        await _authBusinessRules.RefreshTokenShouldBeActive(refreshToken);
        AccessToken token = await _authService.RefreshTokenLoginAsync(request.RefreshToken);
        return new RefreshTokenCommandResponse
        {
            AccessToken = token
        };
    }
}