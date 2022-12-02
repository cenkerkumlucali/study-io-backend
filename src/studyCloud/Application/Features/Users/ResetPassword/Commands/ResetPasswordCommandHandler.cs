using Application.Abstractions.Services;
using Application.Features.Users.User.Rules;
using Application.Repositories.Services.Users;
using MediatR;

namespace Application.Features.Users.ResetPassword.Commands;

public class ResetPasswordCommandHandler:IRequestHandler<ResetPasswordCommandRequest,ResetPasswordCommandResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly IAuthService _authService;
    private readonly IUserService _userService;

    public ResetPasswordCommandHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules, IAuthService authService, IUserService userService)
    {
        _userRepository = userRepository;
        _userBusinessRules = userBusinessRules;
        _authService = authService;
        _userService = userService;
    }

    public async Task<ResetPasswordCommandResponse> Handle(ResetPasswordCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Users.User? user = await _userRepository.GetAsyncNoTracking(c => c.Email == request.Email);
        await _userBusinessRules.UserShouldBeExist(user);
        ResetPasswordCommandResponse resetPasswordCommandResponse = new();

        if (request.AuthenticatorCode is null)
        {
            await _authService.SendResetPasswordAuthenticationCode(user);
            return resetPasswordCommandResponse;
        }
        await _authService.VerifyResetPasswordAuthenticationCode(user, request.AuthenticatorCode);
        await _userBusinessRules.CheckPasswordTheSame(request.Password, request.ConfirmPassword);
        await _userService.ResetPassword(user, request.Password, request.ConfirmPassword);
        return new()
        {
            Message = "Şifre başarıyla değiştirilmiştir."
        };
    }
}