namespace Application.Features.Users.UserImage.Commands.UpdateUserImage;

public class UpdateUserImageCommandResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
}