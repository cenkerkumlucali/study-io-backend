namespace Application.Features.Users.UserImage.Queries.GetListUserImage;

public class ListUserImageQueryResponse
{
    public long Id { get; set; }
    public string UserEmail { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
}