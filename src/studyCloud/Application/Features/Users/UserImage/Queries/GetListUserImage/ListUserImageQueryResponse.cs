namespace Application.Features.Users.UserImage.Queries.GetListUserImage;

public class ListUserImageQueryResponse
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
}