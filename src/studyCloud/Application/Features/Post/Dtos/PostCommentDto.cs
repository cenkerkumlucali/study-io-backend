namespace Application.Features.Post.Dtos;

public class PostCommentDto
{
    public string FullName { get; set; }
    public string Content { get; set; }
    public int LikeCount { get; set; }
    public int CommentCount { get; set; }
    public List<string> Urls { get; set; }
    public DateTime CreatedDate { get; set; }
    public ICollection<PostCommentDto>? Children { get; set; }

}