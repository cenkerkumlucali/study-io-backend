namespace Application.Features.Comments.CommentLike.Dtos;

public class CreatedCommentLikeDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CommentId { get; set; }
}