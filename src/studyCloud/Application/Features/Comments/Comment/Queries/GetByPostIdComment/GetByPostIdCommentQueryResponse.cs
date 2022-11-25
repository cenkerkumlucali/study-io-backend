namespace Application.Features.Comments.Comment.Queries.GetByPostIdComment;

public class GetByPostIdCommentQueryResponse
{
    public string FullName { get; set; }
    public string ProfileImageUrl { get; set; }
    public string Content { get; set; }
    public int CommentCount { get; set; }
    public int CommentLike { get; set; }
    public List<string> Urls { get; set; }
    public DateTime CreatedDate { get; set; }
    public ICollection<GetByPostIdCommentQueryResponse> Replies { get; set; }
}