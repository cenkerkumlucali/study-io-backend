namespace Application.DTOs.User;

public class UserForLoginDto
{
    public string UserNameOrEmail { get; set; }
    public string Password { get; set; }
    public string? AuthenticatorCode { get; set; }
}