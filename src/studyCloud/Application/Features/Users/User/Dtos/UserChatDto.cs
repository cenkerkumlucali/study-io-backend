namespace Application.Features.Users.User.Dtos;

public class UserChatDto
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string PictureUrl { get; set; }
    public bool IsOnline { get; set; }
}