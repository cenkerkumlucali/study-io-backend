namespace Application.Features.Comments.CommentLike.Dtos;

public class GetByIdCommentLikeQueryResponse
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public string Content { get; set; }
}