namespace Application.DTOs.User;

public class UserForRegisterDto
{
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}