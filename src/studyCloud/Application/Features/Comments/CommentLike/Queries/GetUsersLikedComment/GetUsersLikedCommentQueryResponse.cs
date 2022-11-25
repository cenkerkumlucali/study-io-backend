namespace Application.Features.Comments.CommentLike.Queries.GetUsersLikedComment;

public class GetUsersLikedCommentQueryResponse
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string FullName { get; set; }
    public string PictureUrl { get; set; }
}