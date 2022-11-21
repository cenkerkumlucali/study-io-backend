namespace Application.Features.Feeds.Post.Dtos;

public class PostCommentDto
{
    public string FullName { get; set; }
    public string Content { get; set; }
    public ICollection<PostCommentDto>? Childrens { get; set; }
    public int LikeCount { get; set; }
    public int CommentCount { get; set; }
    public DateTime CreatedDate { get; set; }
}