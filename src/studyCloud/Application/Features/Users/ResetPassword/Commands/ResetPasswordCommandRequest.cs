using MediatR;

namespace Application.Features.Users.ResetPassword.Commands;

public class ResetPasswordCommandRequest:IRequest<ResetPasswordCommandResponse>
{
    public string Email { get; set; }
    public string? AuthenticatorCode { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
}