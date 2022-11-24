namespace Application.Features.Users.UserImage.Commands.CreateUserImage;

public class CreateUserImageCommandResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
}