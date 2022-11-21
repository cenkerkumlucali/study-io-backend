using Application.Features.Feeds.Post.Dtos;

namespace Application.Features.Feeds.Post.Queries.GetByIdPost;

public class GetByIdPostQueryResponse
{
    public string FullName { get; set; } 
    public string Content { get; set; }
    public ICollection<PostCommentDto> Comments { get; set; }
    public int CommentCount { get; set; }
    public DateTime CreatedDate { get; set; }
}   