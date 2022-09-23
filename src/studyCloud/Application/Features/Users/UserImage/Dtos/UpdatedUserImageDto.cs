namespace Application.Features.Users.UserImage.Dtos;

public class UpdatedUserImageDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
}