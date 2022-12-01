namespace Application.Features.Feeds.Post.Dtos;

public class PostListDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Content { get; set; }
    public List<string> FilesUrl { get; set; }
    public int LikePostCount { get; set; }
    public int CommentCount { get; set; }
    public DateTime CreatedDate { get; set; }
}