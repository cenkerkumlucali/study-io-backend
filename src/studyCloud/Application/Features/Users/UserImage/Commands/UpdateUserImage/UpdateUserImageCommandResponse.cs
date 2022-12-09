namespace Application.Features.Users.UserImage.Commands.UpdateUserImage;

public class UpdateUserImageCommandResponse
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
}