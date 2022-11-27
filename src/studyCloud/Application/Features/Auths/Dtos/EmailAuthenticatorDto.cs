namespace Application.Features.Auths.Dtos;

public class EmailAuthenticatorDto
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string VerifyEmailUrlPrefix { get; set; }
    public string ActivationKey { get; set; }
    public int RoutingKey { get; set; }
}