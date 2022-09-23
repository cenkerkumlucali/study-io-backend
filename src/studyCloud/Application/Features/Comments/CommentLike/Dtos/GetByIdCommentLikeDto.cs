namespace Application.Features.Comments.CommentLike.Dtos;

public class GetByIdCommentLikeDto
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public string Content { get; set; }
}