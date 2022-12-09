namespace Application.Features.Users.UserImage.Commands.CreateUserImage;

public class CreateUserImageCommandResponse
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
}