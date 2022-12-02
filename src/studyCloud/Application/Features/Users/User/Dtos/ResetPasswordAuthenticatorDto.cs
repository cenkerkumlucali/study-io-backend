namespace Application.Features.Users.User.Dtos;

public class ResetPasswordAuthenticatorDto
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ActivationKey { get; set; }
    public int RoutingKey { get; set; }
}