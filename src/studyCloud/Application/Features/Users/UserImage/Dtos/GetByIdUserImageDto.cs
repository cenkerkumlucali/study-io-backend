namespace Application.Features.Users.UserImage.Dtos;

public class GetByIdUserImageDto
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
}