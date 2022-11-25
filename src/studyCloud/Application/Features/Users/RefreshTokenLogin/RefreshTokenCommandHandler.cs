using Application.Abstractions.Services;
using Application.DTOs.JWT;
using MediatR;

namespace Application.Features.Users.RefreshTokenLogin;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
{
    private readonly IAuthService _authService;

    public RefreshTokenCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request,CancellationToken cancellationToken)
    {
        AccessToken token = await _authService.RefreshTokenLoginAsync(request.RefreshToken);
        return new RefreshTokenCommandResponse
        {
            Token = token
        };
    }
}