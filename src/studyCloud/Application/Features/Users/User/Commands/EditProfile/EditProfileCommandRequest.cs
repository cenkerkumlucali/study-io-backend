using Domain.Enums;
using MediatR;

namespace Application.Features.Users.User.Commands.EditProfile;

public class EditProfileCommandRequest:IRequest<EditProfileCommandResponse>
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Introduce { get; set; }
    public string PhoneNumber { get; set; }
    public Gender Gender { get; set; }
}