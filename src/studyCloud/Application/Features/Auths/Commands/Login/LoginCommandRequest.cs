using Application.DTOs.User;
using MediatR;

namespace Application.Features.Auths.Commands.Login;

public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
    public UserForLoginDto UserForLoginDto { get; set; }
    public string IPAddress { get; set; }
}