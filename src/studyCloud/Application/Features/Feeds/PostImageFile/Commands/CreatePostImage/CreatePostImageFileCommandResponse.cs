namespace Application.Features.Feeds.PostImageFile.Commands.CreatePostImage;

public class CreatePostImageFileCommandResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}