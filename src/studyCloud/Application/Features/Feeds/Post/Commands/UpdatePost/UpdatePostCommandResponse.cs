namespace Application.Features.Feeds.Post.Commands.UpdatePost;

public class UpdatePostCommandResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}