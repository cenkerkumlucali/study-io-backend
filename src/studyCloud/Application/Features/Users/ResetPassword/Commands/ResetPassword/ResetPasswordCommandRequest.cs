using MediatR;

namespace Application.Features.Users.ResetPassword;

public class ResetPasswordCommandRequest:IRequest<ResetPasswordCommandResponse>
{
    public string Email { get; set; }
}