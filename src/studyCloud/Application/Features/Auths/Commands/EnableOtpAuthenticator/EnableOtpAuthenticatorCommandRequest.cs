using Application.Features.Auths.Dtos;
using MediatR;

namespace Application.Features.Auths.Commands.EnableOtpAuthenticator;

public class EnableOtpAuthenticatorCommandRequest : IRequest<EnabledOtpAuthenticatorCommandResponse>
{
    public long UserId { get; set; }
}