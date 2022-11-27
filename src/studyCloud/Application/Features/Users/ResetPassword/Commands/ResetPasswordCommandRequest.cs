using MediatR;

namespace Application.Features.Users.ResetPassword.Commands;

public class ResetPasswordCommandRequest:IRequest
{
    public string Email { get; set; }
    public int RoutingKey => 0;
}