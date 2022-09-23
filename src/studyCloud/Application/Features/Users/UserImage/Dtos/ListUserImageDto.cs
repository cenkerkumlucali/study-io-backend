namespace Application.Features.Users.UserImage.Dtos;

public class ListUserImageDto
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
}