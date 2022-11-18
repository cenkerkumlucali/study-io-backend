namespace Application.Features.Feeds.PostImage.Commands.CreatePostImage;

public class CreatePostFileCommandResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}