namespace Application.Features.Auths.Commands.EnableOtpAuthenticator;

public class EnabledOtpAuthenticatorCommandResponse
{
    public string SecretKey { get; set; }

    public EnabledOtpAuthenticatorCommandResponse()
    {
    }

    public EnabledOtpAuthenticatorCommandResponse(string secretKey)
    {
        SecretKey = secretKey;
    }
}