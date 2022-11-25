namespace Application.Features.Comments.CommentLike.Commands.LikeComment;

public class LikeCommentCommandResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CommentId { get; set; }
}