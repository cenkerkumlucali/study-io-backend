using Application.DTOs.Post;

namespace Application.Features.Feeds.Post.Queries.GetByIdPost;

public class GetByIdPostQueryResponse
{
    public int Id { get; set; }
    public string FullName { get; set; } 
    public string Content { get; set; }
    public ICollection<PostCommentDto> Comments { get; set; }
    public int CommentCount { get; set; }
    public DateTime CreatedDate { get; set; }
}