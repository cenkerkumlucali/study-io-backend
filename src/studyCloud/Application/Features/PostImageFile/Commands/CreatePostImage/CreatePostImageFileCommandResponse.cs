namespace Application.Features.PostImageFile.Commands.CreatePostImage;

public class CreatePostImageFileCommandResponse
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}