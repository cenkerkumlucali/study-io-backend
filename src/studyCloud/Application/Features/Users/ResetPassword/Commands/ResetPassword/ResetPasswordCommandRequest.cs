using MediatR;

namespace Application.Features.Users.ResetPassword.Commands.ResetPassword;

public class ResetPasswordCommandRequest:IRequest<ResetPasswordCommandResponse>
{
    public string Email { get; set; }
}