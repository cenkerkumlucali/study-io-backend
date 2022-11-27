namespace Application.Features.Auths.Dtos;

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