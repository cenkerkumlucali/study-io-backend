using Application.Abstractions.Services;
using Application.DTOs.JWT;
using Application.Features.Auths.Rules;
using MediatR;

namespace Application.Features.Auths.Commands.RefreshToken;

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
        Domain.Entities.Users.RefreshToken? refreshToken = await _authService.GetRefreshTokenByToken(request.RefreshToken);
        await _authBusinessRules.RefreshTokenShouldBeActive(refreshToken);
        AccessToken token = await _authService.RefreshTokenLoginAsync(request.RefreshToken);
        return new RefreshTokenCommandResponse
        {
            AccessToken = token
        };
    }
}