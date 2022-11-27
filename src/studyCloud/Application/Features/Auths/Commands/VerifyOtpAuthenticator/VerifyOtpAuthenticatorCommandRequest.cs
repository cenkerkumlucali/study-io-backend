using MediatR;

namespace Application.Features.Auths.Commands.VerifyOtpAuthenticator;

public class VerifyOtpAuthenticatorCommandRequest : IRequest
{
    public int UserId { get; set; }
    public string ActivationCode { get; set; }
}