namespace Application.Features.Feeds.Post.Commands.CreatePost;

public class CreatePostCommandResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
}