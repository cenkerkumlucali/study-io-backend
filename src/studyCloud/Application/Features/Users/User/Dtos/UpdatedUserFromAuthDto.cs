using Application.DTOs.JWT;

namespace Application.Features.Users.User.Dtos;

public class UpdatedUserFromAuthDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public AccessToken AccessToken { get; set; }
}