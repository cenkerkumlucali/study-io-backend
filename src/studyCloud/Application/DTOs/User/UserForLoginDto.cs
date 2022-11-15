namespace Application.DTOs.User;

public class UserForLoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string? AuthenticatorCode { get; set; }
}